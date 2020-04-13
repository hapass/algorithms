using System;
using System.Linq;
using Xunit;

namespace Strings
{
    public class StringSortingTest
    {
        [Fact]
        public void KeyIndexedStringShouldValidateKeys()
        {
            Assert.Throws<ArgumentException>(() => {
                new KeyIndexedStrings(new KeyValuePair{key = 10, value = "Anderson" });
            });
        }
    }
}