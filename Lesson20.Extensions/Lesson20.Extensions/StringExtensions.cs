using System;

namespace Lesson20.Extensions
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static bool ToBool(this string str)
        {
            return bool.TryParse(str, out bool value) && value;
        }
    }
}