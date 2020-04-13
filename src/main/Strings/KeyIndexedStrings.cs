using System;

namespace Strings
{
    public class KeyValuePair
    {
        public int key = 0;
        public String value = String.Empty;
    }

    public class KeyIndexedStrings
    {
        const int KeyRadix = 10;
        private KeyValuePair[] keyValuePairs;
        private int[] keyFrequencyCounts;

        public KeyIndexedStrings(params KeyValuePair[] keyValuePairs)
        {
            this.keyValuePairs = keyValuePairs;
            this.keyFrequencyCounts = new int[10];

            foreach (var pair in this.keyValuePairs)
            {
                if (pair.key < 0 || pair.key > KeyRadix - 1)
                {
                    throw new ArgumentException("Key should be a number between 0 and 9.");
                }
            }
        }
    }
}
