using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public class SevenDaysDateTime : ISevenDaysDateTime
{
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }

    public SevenDaysDateTime(int day, int hour, int minute)
    {
        Day = day;
        Hour = hour;
        Minute = minute;
    }

    public SevenDaysDateTime(string day, string hour, string minute) : this(int.Parse(day), int.Parse(hour), int.Parse(minute))
    {
    }
}