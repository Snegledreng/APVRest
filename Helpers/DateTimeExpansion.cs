using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APVRest.Helpers
{
    public static class DateTimeExpansion
    {
        public static DateTime RoundDownToHour(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
        }
    }
}
