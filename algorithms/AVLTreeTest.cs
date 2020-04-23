using System;
using Xunit;

namespace Algorithms
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreeFindsValueArray()
        {
            var tree = new AVLTree();

            tree.Add(1, "One");
            tree.Add(2, "Two");
            tree.Add(3, "Three");
            tree.Add(4, "Four");
            tree.Add(5, "Five");
            tree.Add(6, "Six");
            tree.Add(7, "Seven");
            tree.Add(8, "Eight");
            tree.Add(9, "Nine");

            Assert.True(tree.Find(10) == null);
            Assert.True(tree.Find(6) != null);
            Assert.True(tree.Find(6).Value == "Six");
        }
    }
}