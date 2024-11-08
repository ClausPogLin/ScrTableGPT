using Spectre.Console;

namespace ScrTableGPT;

public static class TableOutputTools
{
    public static Table ConvertMarkdownToTable(string markdown)
    {
        var table = new Table();
        
        var lines = markdown.Split('\n');

        bool isHeaderRow = true;
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            
            if (string.IsNullOrWhiteSpace(trimmedLine))
                continue;
            
            if (isHeaderRow)
            {
                var headers = ParseMarkdownRow(trimmedLine);
                foreach (var header in headers)
                {
                    table.AddColumn(header);
                }
                isHeaderRow = false;
            }
            else
            {
                var rowData = ParseMarkdownRow(trimmedLine);
                if (rowData.FindAll( x => x.Trim() == "---").Count != rowData.Count)
                    table.AddRow(rowData.ToArray());
            }
        }

        return table;
    }

    
    private static List<string> ParseMarkdownRow(string row)
    {
        var rowData = new List<string>();
        var cells = row.Split('|');
        foreach (var cell in cells)
        {
            if(cell!="") rowData.Add(cell);
        }
        rowData.RemoveAll(s => s == "");
        return rowData;
    }
}