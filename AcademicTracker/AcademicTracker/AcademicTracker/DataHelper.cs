using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicTracker
{
    public static class DataHelper
    {
        public static string FormatDate(DateTime start, DateTime end)
        {
            return start.ToString("MMMM dd, yyyy") + " to " + end.ToString("MMMM dd, yyyy");
        }

        public static string TitleLimitor(string title, int maxLengeth)
        {
            if (title.Length > maxLengeth)
                return title.Substring(0, maxLengeth) + "...";
            return title;
        }
    }
}
