using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using ScrTableGPT.Models;
using Spectre.Console;
using Calendar = Ical.Net.Calendar;
using CalendarEvent = Ical.Net.CalendarComponents.CalendarEvent;

namespace ScrTableGPT;

public static class CalendarTools
{
    public static string ModelToICSRaw(LmResponse modeledLmResponse)
    {
        var calendar = new Calendar();
        foreach (var dayNum in modeledLmResponse.Days)
        {
            AnsiConsole.MarkupLine($"|[springgreen2 invert] Weekday {dayNum.Weekday}[/]");
            DateTime today = DateTime.Today;
            int weekNumber = dayNum.Weekday;
            DateTime targetDay = DateTools.GetWeekdayOfCurrentWeek(today, weekNumber);
            foreach (var item in dayNum.Items)
            {
                var calendarEvent = new CalendarEvent
                {
                    Summary = item.Title,
                    Location = item.Location,
                    Description = item.Description,
                    Start = new CalDateTime(targetDay.Year, targetDay.Month, targetDay.Day, item.StartTime.Hour, item.StartTime.Minute, item.StartTime.Second),
                    End = new CalDateTime(targetDay.Year, targetDay.Month, targetDay.Day, item.EndTime.Hour, item.EndTime.Minute, item.EndTime.Second),
                };
                var recurrencePattern = new RecurrencePattern(FrequencyType.Weekly, 1);
                calendarEvent.RecurrenceRules.Add(recurrencePattern);
                calendar.Events.Add(calendarEvent);
                AnsiConsole.MarkupLine($"|    [springgreen2] Added item : [bold black on lightskyblue1] {item.Title} [/] [lightskyblue1]{item.Description}[/] at location [bold invert] {item.Location} [/] from [underline invert] {item.StartTime.ToString("t")} - {item.EndTime.ToString("t")} [/].[/]");
                Thread.Sleep(20);
            }
        }
        var serializer = new CalendarSerializer();
        var serializedCalendar = serializer.SerializeToString(calendar);
        return serializedCalendar;
    }
}