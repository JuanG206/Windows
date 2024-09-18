namespace GET_POST;
public class Methods
{
    public static DateTime RoundToNearestQuarterHour(DateTime dateTime)
    {
        int minutes = dateTime.Minute;
        int roundedMinutes = (int)Math.Round((double)minutes / 15) * 15; 
        if (roundedMinutes == 60) 
        {
            dateTime = dateTime.AddHours(1);
            roundedMinutes = 0;
        }
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, roundedMinutes, 0, dateTime.Kind);
    }
}

