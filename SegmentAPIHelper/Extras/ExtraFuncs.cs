using System;

namespace SegmentAPIHelper
{
    public static class ExtraFuncs
    {
        public static string DateToISO8601Format(DateTime? dateTime)
        {
            return dateTime?.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}