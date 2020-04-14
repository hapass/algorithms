using System;

namespace Strings
{
    public static class LSDSort
    {
        public static void SortAscii(this string[] strings)
        {
            int strLength = 0;

            foreach (var str in strings)
            {
                if (strLength == 0)
                {
                    strLength = str.Length;
                }
                else 
                {
                    if (strLength != str.Length)
                    {
                        throw new ArgumentException("All strings should be equal.");
                    }
                }
            }

            for (var i = strLength - 1; i >= 0; i--)
            {
                strings.SortAscii(i);
            }
        }
    }
}
