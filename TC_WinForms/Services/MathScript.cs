﻿using ExcelParsing.DataProcessing;
using NCalc;
using System.Data;
using System.Text.RegularExpressions;

namespace TC_WinForms.Services;

public static class MathScript
{
	/// <summary>
	/// Выполняет вычисление выражения с использованием коэффициента и значения по умолчанию, с возможной подстановкой переменных из словаря.
	/// </summary>
	/// <param name="coefficient">Коэффициент в виде выражения (например, "+0.5 + Q1", "-0.2").</param>
	/// <param name="defaultValue">Значение по умолчанию, используемое в выражении. На него домножается (по умолчанию) выражение с коэффициентом</param>
	/// <param name="coefDict">Необязательный словарь переменных для вычисления выражения.</param>
	/// <returns>Вычисленное значение, округленное до 2 знаков после запятой, или генерирует исключение при ошибке.</returns>
	public static double EvaluateCoefficientExpression(string coefficient, Dictionary<string, double> coefDict, string? defaultValue = null)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(coefficient)) // todo: возможно логичнее возврат defaultValue ?
				throw new ArgumentException("Coefficient cannot be null or empty.", nameof(coefficient));

			var firstChar = coefficient[0];

			// проверка, что коэффициент не является только знак
			if (coefficient.Length == 1 && IsMathSign(firstChar))
				throw new ArgumentException("Коэффициент не может быть знаком.", nameof(coefficient));

			// проверить нет ли в знака первым символом
			// Определяем формат выражения
			string expression;
			if (string.IsNullOrWhiteSpace(defaultValue))
			{
				expression = coefficient;
			}else
			{
				expression = IsMathSign(firstChar)
				? $"{defaultValue}{coefficient}"
				: $"{defaultValue}*({coefficient})";
			}
			

			double value = coefDict?.Count > 0
				? EvaluateExpression(expression, coefDict)
				: EvaluateExpression(expression);

			return Math.Round(value, 2);
		}
		catch (Exception e)
		{
			throw new Exception($"Ошибка в формуле!\n{e}", e);

			//MessageBox.Show($"Ошибка в формуле!\n{e}", "Ошибка формулы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//return -1;
		}

		static bool IsMathSign(char firstChar)
		{
			return (firstChar == '+' || firstChar == '-' || firstChar == '*' || firstChar == '/');
		}
	}
	
	/// <summary>
	/// Выполняет вычисление математического выражения, заданного в виде строки.
	/// </summary>
	/// <param name="expression">Математическое выражение для вычисления.</param>
	/// <returns>Вычисленное значение, округленное до 2 знаков после запятой, или генерирует исключение при ошибке.</returns>
	public static double EvaluateExpression(string expression)
	{
		try
		{
			expression = expression.Trim().Replace(",", ".");
			// разделить выражение на части по разделителю "*" удаляя пустые значения
			var parts = expression.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries);

			// собираем выражение заново
			expression = string.Join("*", parts);

			var table = new DataTable();

			var value = table.Compute(expression, string.Empty);
			return Math.Round(Convert.ToDouble(value), 2);
		}
		catch
		{
			throw new Exception($"Произошла ошибка при расчёте выражения {expression}");

		}

	}

	/// <summary>
	/// Выполняет вычисление математического выражения с подстановкой переменных.
	/// </summary>
	/// <param name="expression">Математическое выражение для вычисления.</param>
	/// <param name="variables">Словарь, где ключи - имена переменных, а значения - их числовые значения.</param>
	/// <returns>Результат вычисления в виде числа double или генерирует исключение при ошибке.</returns>
	private static double EvaluateExpression(string expression, Dictionary<string, double> variables)
	{
		var formattedExpression = expression.Replace(',', '.');

		// Создаем новое выражение
		Expression e = new Expression(formattedExpression);

		// Извлекаем список переменных из выражения
		var parameters = new List<string>();

		// Регулярное выражение для поиска идентификаторов (переменных)
		Regex regex = new Regex(@"[a-zA-Z_]\w*");

		MatchCollection matches = regex.Matches(formattedExpression);

		foreach (Match match in matches)
		{
			string paramName = match.Value;

			// Исключаем функции и операторы
			if (!IsFunction(paramName) && !IsOperator(paramName))
			{
				parameters.Add(paramName);
			}
		}

		// Убираем дубликаты переменных
		parameters = parameters.Distinct().ToList();

		// Проверяем наличие всех переменных в словаре
		foreach (var param in parameters)
		{
			if (!variables.ContainsKey(param))
			{
				throw new ArgumentException($"Переменная '{param}' отсутствует в данной ТК.");
			}
		}

		// Передаем переменные в выражение
		foreach (var variable in variables)
		{
			e.Parameters[variable.Key] = variable.Value;
		}

		// Вычисляем результат
		object result = e.Evaluate();

		// Преобразуем результат в double и возвращаем
		return Convert.ToDouble(result);
	}

	/// <summary>
	/// Проверяет, является ли указанный идентификатор поддерживаемой функцией библиотеки NCalc.
	/// </summary>
	/// <param name="name">Идентификатор для проверки.</param>
	/// <returns>True, если идентификатор является функцией, иначе false.</returns>
	private static bool IsFunction(string name)
	{
		// Список функций, поддерживаемых NCalc
		string[] functions = new string[]
		{
		"Abs", "Acos", "Asin", "Atan", "Ceiling", "Cos", "Exp",
		"Floor", "IEEERemainder", "Log", "Log10", "Pow", "Round",
		"Sign", "Sin", "Sqrt", "Tan", "Truncate", "Max", "Min",
		"If", "In", "Not", "Len", "Lower", "Upper", "Contains",
		"StartsWith", "EndsWith", "Substring", "IsNull", "ToInt32",
		"ToDouble", "ToString", "DateTime", "Now", "Today", "Ticks"
		};

		return functions.Contains(name, StringComparer.OrdinalIgnoreCase);
	}

	/// <summary>
	/// Проверяет, является ли указанный идентификатор поддерживаемым оператором библиотеки NCalc.
	/// </summary>
	/// <param name="name">Идентификатор для проверки.</param>
	/// <returns>True, если идентификатор является оператором, иначе false.</returns>
	private static bool IsOperator(string name)
	{
		// Список операторов, поддерживаемых NCalc
		string[] operators = new string[]
		{
		"and", "or", "not", "!", "+", "-", "*", "/", "%", "^",
		"=", "<>", "!=", ">", ">=", "<", "<=", "&&", "||"
		};

		return operators.Contains(name, StringComparer.OrdinalIgnoreCase);
	}
}