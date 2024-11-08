using System.Diagnostics;
using System.Text.Json.Nodes;
using GroqApiLibrary;
using Spectre.Console;

namespace ScrTableGPT;

public static class LMTools
{
    public async static Task<string> AskFor(string content)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var apiKey = Data.GROQ_API_KEY;
        var groqApi = new GroqApiClient(apiKey);

        var request = new JsonObject
        {
            ["model"] = Data.MODEL,
            ["temperature"] = 0.5,
            ["max_tokens"] = 8192,
            ["top_p"] = 1,
            ["stream"] = true,
            ["stop"] = null,
            ["messages"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "system",
                    ["content"] = Data.LM_PROMT
                },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = content
                }
            }
        };
        string liveResponse = "";
        AnsiConsole.MarkupLine($"[bold black on lightskyblue1] GENERATING [/]");
        await foreach (var chunk in groqApi.CreateChatCompletionStreamAsync(request))
        {
            var delta = chunk?["choices"]?[0]?["delta"]?["content"]?.ToString() ?? string.Empty;
            liveResponse += delta;
            /*if (delta == "[")
                delta = "[[";
            else if (delta == "]")
                delta = "]]";*/
            //AnsiConsole.Markup($"{delta}".EscapeMarkup());
            Console.Write(delta);
        }

        //var result = await groqApi.CreateChatCompletionAsync(request);
        //var rawText = result?["choices"]?[0]?["message"]?["content"]?.ToString();
        stopwatch.Stop();
        
        //Console.WriteLine(rawText);
        AnsiConsole.MarkupLine($"""
                                
                                [bold springgreen1]| - ML Model [bold black on blue] {Data.MODEL} [/] responsed.[/]
                                |
                                |    [springgreen4] Answer length : [bold black on lightskyblue1] {liveResponse.Length} [/] letters.[/]
                                |    [springgreen4] Timespan : [bold black on springgreen1] {stopwatch.ElapsedMilliseconds} [/] ms.[/]
                                |
                                """);
        return liveResponse;
    }
}