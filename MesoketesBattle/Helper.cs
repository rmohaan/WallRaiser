using System;
using System.Text.RegularExpressions;

namespace MesoketesBattle
{
    public static class Helper
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            T t;
            if (!Enum.TryParse(value, true, out t))
            {
                Console.WriteLine("Unidentified {0}, Success rate is not reliable", typeof(T).Name);
            }
            return t;
        }

        public static int ValidateTroopInput(this string value)
        {
            const string troopPattern = @"[T](\d-[N|S|W|E]-[X|Z]-\d+)*";
            var rex = new Regex(troopPattern);
            var mat = rex.Matches(value);
            return mat.Count;
        }

        public static int ValidateDayInput(this string value)
        {
            const string dayPattern = @"(Day\d+[$])";
            var rex = new Regex(dayPattern);
            var mat = rex.Matches(value);
            return mat.Count;
        }

        public static string RemoveWhiteSpaces(this string input)
        {
            string pattern = @"\s+"; // "Day.*;+ ";
            string replacement = "";
            var rex = new Regex(pattern);
            var mat = rex.Replace(input, replacement);
            return mat;
        }
    }
}
