using Ical.Net.DataTypes;

namespace ScrTableGPT;

public static class DateTools
{
    public static DateTime GetWeekdayOfCurrentWeek(DateTime referenceDate, int targetDay)
    {
        int currentDayOfWeek = (int)referenceDate.DayOfWeek;

        targetDay = targetDay % 7;  

        int diff = targetDay - (currentDayOfWeek == 0 ? 7 : currentDayOfWeek);

        DateTime targetDate = referenceDate.AddDays(diff);

        return targetDate;
    }
    
}