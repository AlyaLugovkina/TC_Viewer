﻿using ExcelParsing.DataProcessing;
using System.Drawing;

namespace TC_WinForms.DataProcessing;

public class ExExportTC
{
    private DbConnector dbCon = new DbConnector();
    public ExExportTC()
    {
        
    }

    public async Task SaveTCtoExcelFile(string tcArticle, int tcId)
    {
        try
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Настройка диалога сохранения файла
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                saveFileDialog.FileName = tcArticle;

                // Показ диалога пользователю и проверка, что он нажал кнопку "Сохранить"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var tc = await dbCon.GetTechnologicalCardToExportAsync(tcId);
                        if (tc == null)
                        {
                            MessageBox.Show("Ошибка при загрузки данных из БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var excelExporter = new TCExcelExporter();
                        excelExporter.ExportTCtoFile(saveFileDialog.FileName, tc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка при загрузке данных: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Произошла ошибка при сохранении файла: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
