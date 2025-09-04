namespace AP2.S2023A2Console
{
    // c# extension methods
    // used to match syntax of the given AP2 exercise
    public static class DateTimeExtensions
    {
        public static int getDay(this DateTime dateTime)
        {
            return dateTime.Day;
        }
        
        public static int getHour(this DateTime dateTime)
        {
            return dateTime.Hour;
        }

        public static int getDaysOfMonth(this DateTime dateTime)
        {
            return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        }
    }
}
