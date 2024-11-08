using System.Text;
using OfficeOpenXml;

namespace ScrTableGPT;

public static class TableTools
{
    public static string ExcelToMarkdown(string filePath)
    {
        StringBuilder markdown = new StringBuilder();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            for (int col = 1; col <= colCount; col++)
            {
                markdown.Append($"| {worksheet.Cells[1, col].Text} ");
            }
            markdown.AppendLine("|");

            for (int col = 1; col <= colCount; col++)
            {
                markdown.Append("| --- ");
            }
            markdown.AppendLine("|");

            for (int row = 2; row <= rowCount; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    string cellValue = worksheet.Cells[row, col].Text;
                    string cleanedCellValue = cellValue.Replace("\r", " ").Replace("\n", " "); // 将回车换行替换为空格
                    markdown.Append($"| {cleanedCellValue} ");
                }
                markdown.AppendLine("|");
            }
        }

        return markdown.ToString();
    }
}