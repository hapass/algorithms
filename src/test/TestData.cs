using System;
using System.Linq;

namespace Algorithms
{
    public static class TestData
    {

        public static IComparable[] GetUnsortedCharArray()
        {
            return "QUITEEXCELLENTSORTTESTWITHOUTREPEATINGLETTERS"
                .ToCharArray()
                .Distinct()
                .Select(e => e as IComparable)
                .Where(e => e != null)
                .ToArray();
        }
    }
}