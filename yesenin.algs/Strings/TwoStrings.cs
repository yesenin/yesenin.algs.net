using System;

namespace yesenin.algs.Strings
{
    /// <summary>
    /// Method for two strings
    /// </summary>
    public static class TwoStrings
    {
        /// <summary>
        /// Gets two strings and returns merged one.
        /// </summary>
        /// <param name="a">Base string</param>
        /// <param name="b">String which will be merged</param>
        /// <returns>Merged string</returns>
        public static string Merge(string a, string b)
        {
            var i = 1;
            var maxIndex = -1;
            while (i < b.Length)
            {
                var bSub = b.Substring(0, i);
                var index = a.LastIndexOf(bSub, StringComparison.Ordinal);
                if (index >= 0 && index == a.Length - bSub.Length && index > maxIndex)
                {
                    maxIndex = index;
                }

                i += 1;
            }

            if (maxIndex >= 0)
            {
                a = a.Substring(0, maxIndex);
            }
            return $"{a}{b}";
        }
    }
}