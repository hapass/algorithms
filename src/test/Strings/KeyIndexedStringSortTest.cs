using System;
using System.Linq;
using Xunit;
using Sorting;

namespace Strings
{
    public class KeyIndexedStringsTest
    {
        [Fact]
        public void ShouldSortKeyIndexedStrings()
        {
            var keyIndexedStrings = new [] {
                "ABC1",
                "ABCA",
                "ABC2",
                "ABCA",
                "ABC0",
                "ABCC",
                "ABCD"
            };
            keyIndexedStrings.SortAscii(3);
            Assert.True(keyIndexedStrings.IsSorted());
        }

        [Fact]
        public void ShouldThrowIfNotAscii()
        {
            var keyIndexedStrings = new [] { "ABCД" };

            Assert.ThrowsAny<ArgumentException>(() => {
                keyIndexedStrings.SortAscii(3);
            });
        }

        [Fact]
        public void ShouldThrowIfIndexOutOfRange()
        {
            var keyIndexedStrings = new [] { "ABC0" };

            Assert.ThrowsAny<ArgumentException>(() => {
                keyIndexedStrings.SortAscii(5);
            });
        }
    }
}