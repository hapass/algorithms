using System;
using System.Linq;
using Xunit;
using Sorting;

namespace Strings
{
    public class KeyIndexedStringsTest
    {
        [Fact]
        public void ShouldKeyIndexedSortStrings()
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

        [Fact]
        public void ShouldThrowIfStringsNotEqualLength()
        {
            var lsdStrings = new [] { 
                "4PGC938",
                "2IYE2301",
            };

            Assert.ThrowsAny<ArgumentException>(() => {
                lsdStrings.SortAscii();
            });
        }

        [Fact]
        public void ShouldLSDSortStrings()
        {
            var lsdStrings = new [] { 
                "4PGC938",
                "2IYE230",
                "3CIO720",
                "1ICK750",
                "1OHV845",
                "4JZY524",
                "1ICK750",
                "3CIO720",
                "1OHV845",
                "1OHV845",
                "2RLA629",
                "2RLA629",
                "3ATW723",
            };

            lsdStrings.SortAscii();

            Assert.True(lsdStrings.IsSorted());
        }
    }
}