﻿using OfficeOpenXml;
using TcModels.Models;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;

namespace ExcelParsing.DataProcessing
{
    public class ExcelParser
    {
        public const int maxRow = 10000;
        public const int maxColumn = 20;

        public const int addToTitleRow = 1;
        public const int addToTable = addToTitleRow + 1;
        public ExcelParser()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }
        public List<Staff> ParseExcelToStaffObjects(string filePath)
        {
            var staffList = new List<Staff>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Staff"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var staff = new Staff
                    {
                        Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        Name = Convert.ToString(worksheet.Cells[row, 2].Value),
                        Type = Convert.ToString(worksheet.Cells[row, 3].Value),
                        Functions = Convert.ToString(worksheet.Cells[row, 5].Value),
                        CombineResponsibility = Convert.ToString(worksheet.Cells[row, 6].Value),
                        Qualification = Convert.ToString(worksheet.Cells[row, 7].Value),
                        Comment = Convert.ToString(worksheet.Cells[row, 8].Value)
                    };

                    staffList.Add(staff);
                }
            }

            return staffList;
        }
        public List<Protection> ParseExcelToObjectsProtection(string filePath)
        {
            var objList = new List<Protection>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Protect"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var obj = new Protection
                    {
                        Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        Name = Convert.ToString(worksheet.Cells[row, 2].Value),
                        Type = Convert.ToString(worksheet.Cells[row, 3].Value),
                        Unit = Convert.ToString(worksheet.Cells[row, 4].Value),
                        
                        Description = Convert.ToString(worksheet.Cells[row, 7].Value),
                        Manufacturer = Convert.ToString(worksheet.Cells[row, 8].Value),

                    };

                    objList.Add(obj);
                }
            }

            return objList;
        }
        public List<Machine> ParseExcelToObjectsMachine(string filePath)
        {
            var objList = new List<Machine>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Machinery"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var obj = new Machine
                    {
                        Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        Name = Convert.ToString(worksheet.Cells[row, 2].Value),
                        Type = Convert.ToString(worksheet.Cells[row, 3].Value),
                        Unit = Convert.ToString(worksheet.Cells[row, 4].Value),

                        Description = Convert.ToString(worksheet.Cells[row, 6].Value),
                        Manufacturer = Convert.ToString(worksheet.Cells[row, 7].Value),

                    };

                    objList.Add(obj);
                }
            }

            return objList;
        }
        public List<Component> ParseExcelToObjectsComponent(string filePath)
        {
            var objList = new List<Component>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Component"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var obj = new Component
                    {
                        //Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        Name = Convert.ToString(worksheet.Cells[row, 2].Value),
                        Type = Convert.ToString(worksheet.Cells[row, 3].Value),
                        Unit = Convert.ToString(worksheet.Cells[row, 4].Value),
                        Price = Convert.ToSingle(worksheet.Cells[row, 6].Value),
                        Description = Convert.ToString(worksheet.Cells[row, 7].Value),
                        Manufacturer = Convert.ToString(worksheet.Cells[row, 8].Value),
                        Categoty = Convert.ToString(worksheet.Cells[row, 10].Value),

                    };

                    objList.Add(obj);
                }
            }

            return objList;
        }
        public List<Tool> ParseExcelToObjectsTool(string filePath)
        {
            var objList = new List<Tool>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Tools"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var obj = new Tool
                    {
                        //Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        Name = Convert.ToString(worksheet.Cells[row, 2].Value),
                        Type = Convert.ToString(worksheet.Cells[row, 3].Value),
                        Unit = Convert.ToString(worksheet.Cells[row, 4].Value),
                        //Price = Convert.ToSingle(worksheet.Cells[row, 6].Value),
                        Description = Convert.ToString(worksheet.Cells[row, 7].Value),
                        Manufacturer = Convert.ToString(worksheet.Cells[row, 8].Value),
                        Categoty = Convert.ToString(worksheet.Cells[row, 9].Value),

                    };

                    objList.Add(obj);
                }
            }

            return objList;
        }

        public List<List<string>> ParseRowsToStrings(List<string> columnsNames, string filepath, 
            string? sheetName = null, int sheetNumber = 0, int startRow = 1, int endRow = maxRow)
        {
            List<List<string>> structs = new();

            if (sheetName == null && sheetNumber == 0) sheetNumber = 1;
            if (sheetName != null && sheetNumber != 0) throw new Exception("sheetName and sheetNumber can't be set at the same time");
            
            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                // determine sheet name by number
                if (sheetName == null)
                {
                    // get sheets names
                    List<string> sheetsNames = new();
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        sheetsNames.Add(sheet.Name);
                    }
                    sheetName = sheetsNames[sheetNumber - 1];
                }

                var worksheet = package.Workbook.Worksheets[sheetName];
                
                // find end row as last not empty row
                if (endRow == maxRow) endRow = worksheet.Dimension.End.Row;

                int columnNameRow = startRow + addToTitleRow;

                var columnsNums = FindListColumn(columnsNames, columnNameRow, worksheet);
                // todo - check if all columnsNums equals 0 - throw exception
                // todo - check whick columnsNums equals 0 - throw exception with columns names

                // todo - don't breake the code if columnsNums contains 0

                if (columnsNums.Contains(0)) throw new Exception("Can't find column name in the table");
                for (int i = startRow + addToTable; i < endRow; i++)
                {
                    // todo - add try catch block to get exceptions in row parsing and save them to history
                    List<string> rowValues = GetCellsValue(worksheet, columnsNums, i);
                    structs.Add(rowValues);
                }
            }
            return structs;
        }

        private List<int> FindListColumn(List<string> columnNameList, int columnRow, ExcelWorksheet worksheet)
        {
            List<int> numsColumns = new List<int>();
            for (int i = 0; i < columnNameList.Count; i++)
            {
                numsColumns.Add(FindColumn(columnNameList[i], columnRow, worksheet));
            }
            return numsColumns;
        }
        private int FindColumn(string columnName, int columnRow, ExcelWorksheet worksheet)
        {
            string[] columnNameList = { columnName };
            return FindColumn(columnNameList, columnRow, worksheet);
        }
        private int FindColumn(string[] columnNameList, int columnRow, ExcelWorksheet worksheet)
        {
            int numColumn = 0;
            for (int i = 1; i < maxColumn; i++)
            {
                if (worksheet.Cells[columnRow, i].Value != null && columnNameList.Contains(worksheet.Cells[columnRow, i].Value.ToString()))
                { numColumn = i; break; }
            }
            return numColumn;
        }
        private string GetCellValue(int row, int column, ExcelWorksheet worksheet)
        {
            return worksheet.Cells[row, column].Value?.ToString()?.Trim();
        }
        private string? GetCellValue(int row, int column, ExcelWorksheet worksheet, string? defaultValue)
        {
            return GetCellValue(row, column, worksheet) ?? defaultValue; // 
        }
        private List<string> GetCellsValue(ExcelWorksheet worksheet, List<int> columns, int row)
        {
            List<string> values = new List<string>();
            foreach (var column in columns)
            {
                values.Add(GetCellValue(row, column, worksheet, ""));
            }
            return values;
        }

        public void FindTableBorderRows(Dictionary<string, EModelType> keyValuePairs, string filepath, 
            out Dictionary<EModelType?, int> modelStartRows,
            out Dictionary<EModelType?, int> modelEndRows,
            string? sheetName = null, int sheetNumber = 0)
        {
            modelStartRows = new();
            modelEndRows = new();

            if (sheetName == null && sheetNumber == 0) sheetNumber = 1;
            if (sheetName != null && sheetNumber != 0) throw new Exception("sheetName and sheetNumber can't be set at the same time");

            foreach (var item in keyValuePairs)
            {
                modelStartRows.Add(item.Value, 0);
                modelEndRows.Add(item.Value, 0);
            }

            EModelType? currentTableType = null;

            bool lastTableStarts = false;

            using (var package = new ExcelPackage(new FileInfo(filepath)))
            {
                // determine sheet name by number
                if (sheetName == null)
                {
                    // get sheets names
                    List<string> sheetsNames = new();
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        sheetsNames.Add(sheet.Name);
                    }
                    sheetName = sheetsNames[sheetNumber - 1];
                }
                var worksheet = package.Workbook.Worksheets[sheetName];
                for (int i = 1; i < maxRow; i++)
                {
                    string valueCell = worksheet.Cells[i, 1].Value != null ? worksheet.Cells[i, 1].Value.ToString() : "";

                    if (keyValuePairs.Keys.Contains(valueCell))
                    {
                        foreach (var item in keyValuePairs)
                        {
                            if (item.Key == valueCell)
                            {
                                if (currentTableType != null) modelEndRows[currentTableType] = i - 1;
                                currentTableType = item.Value;
                                modelStartRows[item.Value] = i;

                                // check if it is last table (as if it no one 0 value in modelStartRows)
                                if (!modelStartRows.Values.Contains(0)) { lastTableStarts = true; }
                                break;
                            }
                        }
                    }
                    // looking for last row of last table as first row whith null or unparsable it double value in "A" column
                    if (lastTableStarts && i > modelStartRows[currentTableType] + 1)
                    {
                        if (valueCell == "" || !double.TryParse(valueCell, out double _))
                        {
                            modelEndRows[currentTableType] = i - 1;
                            break;
                        }
                    }
                }
            }
        }
    }
}
