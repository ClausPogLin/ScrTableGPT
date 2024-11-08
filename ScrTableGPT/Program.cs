
using System.Diagnostics;
using OfficeOpenXml;
using Spectre.Console;

namespace ScrTableGPT;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine(Data.CONSOLE_TITLE);

        if (args.Length != 1)
        {
            Console.WriteLine("Provide the path to the table file.");
            return;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' did not exist.");
            return;
        }

#if !DEBUG
        try
        {
            string markdownTable = TableTools.ExcelToMarkdown(filePath);
            
            Console.WriteLine(TableOutputTools.ConvertMarkdownToTable(markdownTable));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occur: {ex.Message}");
        }
#else
        string markdownTable = TableTools.ExcelToMarkdown(filePath);

        AnsiConsole.Write(TableOutputTools.ConvertMarkdownToTable(markdownTable));
#endif
        AnsiConsole.MarkupLine("[bold chartreuse2]| Table was converted successfully[/]");

        AnsiConsole.MarkupLine(
            $"[bold chartreuse2]| - ML Model[/] [bold black on blue] {Data.MODEL} [/] [bold chartreuse2]answering...[/]");

        string answer = await LMTools.AskFor(markdownTable);
        var modeledData = Models.LmResponse.FromJson(answer);
        AnsiConsole.MarkupLine("[bold chartreuse2]| Creating a new calendar...[/]");
        var calendarData = CalendarTools.ModelToICSRaw(modeledData);
        
        AnsiConsole.MarkupLine($"[bold chartreuse2]| Starting local port on {Data.LOCAL_PORT}...[/]");
        HttpListenerTools.StartListening(calendarData);
        
    }
}