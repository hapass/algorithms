using System;
using System.Linq;
using Xunit;

namespace Strings
{
    public class KeyIndexedStringsTest
    {
        [Fact]
        public void ShouldValidateKeysUponCreation()
        {
            Assert.Throws<ArgumentException>(() => {
                new KeyIndexedStrings(new KeyValuePair {key = 10, value = "Anderson" });
            });
        }

        [Fact]
        public void ShouldCountKeyFrequencies()
        {
            var keyIndexedStrings = GetTestData();

            keyIndexedStrings.CountKeyFrequencies();

            Assert.Equal(0, keyIndexedStrings.GetKeyFrequency(0));
            Assert.Equal(3, keyIndexedStrings.GetKeyFrequency(1));
            Assert.Equal(5, keyIndexedStrings.GetKeyFrequency(2));
            Assert.Equal(6, keyIndexedStrings.GetKeyFrequency(3));
            Assert.Equal(6, keyIndexedStrings.GetKeyFrequency(4));
        }

        [Fact]
        public void ShouldCountKeyStartingIndexes()
        {
            var keyIndexedStrings = GetTestData();

            keyIndexedStrings.CountKeyFrequencies();
            keyIndexedStrings.CountKeyIndices();

            Assert.Equal(0, keyIndexedStrings.GetKeyIndex(0));
            Assert.Equal(0, keyIndexedStrings.GetKeyIndex(1));
            Assert.Equal(3, keyIndexedStrings.GetKeyIndex(2));
            Assert.Equal(8, keyIndexedStrings.GetKeyIndex(3));
            Assert.Equal(14, keyIndexedStrings.GetKeyIndex(4));
            Assert.Equal(20, keyIndexedStrings.GetKeyIndex(5));
        }

        private KeyIndexedStrings GetTestData()
        {
            return new KeyIndexedStrings(
                new KeyValuePair { key = 2, value = "Anderson" },
                new KeyValuePair { key = 3, value = "Brown" },
                new KeyValuePair { key = 3, value = "Davis" },
                new KeyValuePair { key = 4, value = "Garcia" },
                new KeyValuePair { key = 1, value = "Harris" },
                new KeyValuePair { key = 3, value = "Jackson" },
                new KeyValuePair { key = 4, value = "Johnson" },
                new KeyValuePair { key = 3, value = "Jones" },
                new KeyValuePair { key = 1, value = "Martin" },
                new KeyValuePair { key = 2, value = "Martinez" },
                new KeyValuePair { key = 2, value = "Miller" },
                new KeyValuePair { key = 1, value = "Moore" },
                new KeyValuePair { key = 2, value = "Robinson" },
                new KeyValuePair { key = 4, value = "Smith" },
                new KeyValuePair { key = 3, value = "Taylor" },
                new KeyValuePair { key = 4, value = "Thomas" },
                new KeyValuePair { key = 4, value = "Thompson" },
                new KeyValuePair { key = 2, value = "White" },
                new KeyValuePair { key = 3, value = "Williams" },
                new KeyValuePair { key = 4, value = "Wilson" }
            );
        }
    }
}