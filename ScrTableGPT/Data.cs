using System.Net;

namespace ScrTableGPT;

public static class Data
{
    public const string GROQ_API_KEY = "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";
    public const string LM_PROMT  = "You are a schedule assistant responsible for processing and separating relevant information from the input Markdown schedule table, such as the title, location, start time, end time, and notes, and converting them into a fixed JSON format for output. These schedules may repeat weekly, so the week number of the schedule should be included in the output. The title MUST accurately describe the event rather than a number, index , timespan description (such as \\\"the nth class,晨读, 第x节, xx时段\\\") or a time (such as \\\"lunchtime\\\" or \\\"between classes\\\"). Cells with no information must be skipped, only retaining cells with sufficient information. The JSON output format is as follows:\\n{\\n  \\\"Days\\\":[\\n    {\\n      \\\"Weekday\\\" : 1,\\n      \\\"Items\\\" : [{\\n        \\\"Title\\\" : \\\"语文A02\\\",\\n        \\\"Location\\\": \\\"A502教室\\\",\\n        \\\"Description\\\": \\\"教师: AAA\\\",\\n        \\\"StartTime\\\": \\\"07:20:00\\\",\\n        \\\"EndTime\\\": \\\"07:50:00\\\"\\n      },\\n        {\\n          \\\"Title\\\" : \\\"英语A01\\\",\\n          \\\"Location\\\": \\\"A502教室\\\",\\n          \\\"Description\\\": \\\"教师: BBB\\\",\\n          \\\"StartTime\\\": \\\"08:00:00\\\",\\n          \\\"EndTime\\\": \\\"08:40:00\\\"\\n        }]\\n    },{\\n      \\\"Weekday\\\" : 2,\\n      \\\"Items\\\" : [{\\n        \\\"Title\\\" : \\\"英语A01\\\",\\n        \\\"Location\\\": \\\"A502教室\\\",\\n        \\\"Description\\\": \\\"教师: CCC\\\",\\n        \\\"StartTime\\\": \\\"07:20:00\\\",\\n        \\\"EndTime\\\": \\\"07:50:00\\\"\\n      },\\n        {\\n          \\\"Title\\\" : \\\"语文A01\\\",\\n          \\\"Location\\\": \\\"A502教室\\\",\\n          \\\"Description\\\": \\\"教师: DDD\\\",\\n          \\\"StartTime\\\": \\\"08:00:00\\\",\\n          \\\"EndTime\\\": \\\"08:40:00\\\"\\n        }]\\n    }\\n  ]\\n}\\nThis information is to be converted by you, and you should directly output the result in JSON format. The information must be checked for accuracy and correctness, and only JSON should be output without any additional text.";
    public const string MODEL = "llama-3.2-90b-text-preview";
    public const string LOCAL_PORT = "2952";
    
    public const string CONSOLE_TITLE = " ____                   ______          __       ___           ____    ____    ______   \n/\\  _`\\                /\\__  _\\        /\\ \\     /\\_ \\         /\\  _`\\ /\\  _`\\ /\\__  _\\  \n\\ \\,\\L\\_\\    ___   _ __\\/_/\\ \\/    __  \\ \\ \\____\\//\\ \\      __\\ \\ \\L\\_\\ \\ \\L\\ \\/_/\\ \\/  \n \\/_\\__ \\   /'___\\/\\`'__\\ \\ \\ \\  /'__`\\ \\ \\ '__`\\ \\ \\ \\   /'__`\\ \\ \\L_L\\ \\ ,__/  \\ \\ \\  \n   /\\ \\L\\ \\/\\ \\__/\\ \\ \\/   \\ \\ \\/\\ \\L\\.\\_\\ \\ \\L\\ \\ \\_\\ \\_/\\  __/\\ \\ \\/, \\ \\ \\/    \\ \\ \\ \n   \\ `\\____\\ \\____\\\\ \\_\\    \\ \\_\\ \\__/.\\_\\\\ \\_,__/ /\\____\\ \\____\\\\ \\____/\\ \\_\\     \\ \\_\\\n    \\/_____/\\/____/ \\/_/     \\/_/\\/__/\\/_/ \\/___/  \\/____/\\/____/ \\/___/  \\/_/      \\/_/\n                                                                                        \n                                                                                        ";
    
    public class ListenerData
    {
        public HttpListener Listener { get; set; }
        public string Data { get; set; }
    }
}