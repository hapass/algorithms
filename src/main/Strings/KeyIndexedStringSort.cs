using System;
using System.Linq;

namespace Strings
{
    public static class KeyIndexedStringSort
    {
        public static void SortAscii(this string[] strings, int charIndex)
        {
            int asciiRadix = 256;

            foreach (var str in strings)
            {
                if (charIndex < 0 || charIndex >= str.Length)
                {
                    throw new ArgumentException("Char index is invalid.");
                }

                foreach(var ch in str)
                {
                    int code = Convert.ToInt32(ch);
                    if (code < 0 || code > asciiRadix)
                    {
                        throw new ArgumentException("String chars should be in ascii code point range.");
                    }
                }
            }

            int[] keyCounts = new int[asciiRadix];
            int[] keyPositions = new int[asciiRadix];

            //count distinct keys
            foreach (var str in strings)
            {
                keyCounts[str[charIndex]]++;
            }

            //key == 0 is always first
            keyPositions[0] = 0;
            for (int key = 1; key < asciiRadix; key++)
            {
                //key position = previous key position + previous key count
                keyPositions[key] = keyPositions[key - 1] + keyCounts[key - 1];
            }

            string[] tempStrings = new string[strings.Length];
            strings.CopyTo(tempStrings, 0);

            foreach (var str in tempStrings)
            {
                //insert item to appropriate index
                strings[keyPositions[str[charIndex]]] = str;
                //increment index for other values with same key
                keyPositions[str[charIndex]]++;
            }
        }
    }
}
