using System;
using System.Linq;

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
        public KeyValuePair[] keyValuePairs;
        public KeyValuePair[] sortedKeyValuePairs;
        public int[] keyFrequencyCounts;
        public int[] keyIndices;

        public KeyIndexedStrings(params KeyValuePair[] keyValuePairs)
        {
            this.keyValuePairs = keyValuePairs;
            this.sortedKeyValuePairs = new KeyValuePair[this.keyValuePairs.Length];
            this.keyFrequencyCounts = new int[KeyRadix];
            this.keyIndices = new int[KeyRadix];

            foreach (var pair in this.keyValuePairs)
            {
                if (pair.key < 0 || pair.key >= KeyRadix)
                {
                    throw new ArgumentException("Key should be a number between 0 and 9.");
                }
            }
        }

        public void CountKeyFrequencies()
        {
            foreach (var pair in this.keyValuePairs)
            {
                keyFrequencyCounts[pair.key]++;
            }
        }

        public int GetKeyFrequency(int key)
        {
            return this.keyFrequencyCounts[key];
        }

        public void CountKeyIndices()
        {
            //key == 0 is always first
            this.keyIndices[0] = 0;
            for (int key = 1; key < KeyRadix; key++)
            {
                //key position = previous key position + previous key count
                this.keyIndices[key] = this.keyIndices[key - 1] + this.keyFrequencyCounts[key - 1];
            }
        }

        public int GetKeyIndex(int key)
        {
            return this.keyIndices[key];
        }

        public void Sort()
        {
            foreach (var keyValuePair in this.keyValuePairs)
            {
                //insert item to appropriate index
                this.sortedKeyValuePairs[this.keyIndices[keyValuePair.key]] = keyValuePair;
                //increment index for other values with same key
                this.keyIndices[keyValuePair.key]++;
            }
        }

        public IComparable[] GetSortedKeys()
        {
            return this.sortedKeyValuePairs.Select(p => (IComparable)p.key).ToArray();
        }
    }
}
