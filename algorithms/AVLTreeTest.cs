using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreeIsBuiltProperly()
        {
            Node referenceTree = new Node(0) {
                Key = 40,
                Left = new Node(0) {
                    Key = 20,
                    Left = new Node(0) {
                        Key = 5,
                        Left = new Node(0) {
                            Key = 1
                        },
                        Right = new Node(0) {
                            Key = 10
                        }
                    },
                    Right = new Node(0) {
                        Key = 27,
                        Left = new Node(0) {
                            Key = 25
                        },
                        Right = new Node(0) {
                            Key = 30
                        }
                    }
                },
                Right = new Node(0) {
                    Key = 60,
                    Left = new Node(0) {
                        Key = 50
                    },
                    Right = new Node(0) {
                        Key = 70,
                        Right = new Node(0) {
                            Key = 80
                        }
                    }
                }
            };

            var avlTree = new AVLTree();

            //initial left rotate
            avlTree.Add(10);
            avlTree.Add(20);
            avlTree.Add(30);

            //left rotate on subtree
            avlTree.Add(40);
            avlTree.Add(50);

            //right rotate
            avlTree.Add(5);
            avlTree.Add(1);

            //left, right rotate
            avlTree.Add(25);
            avlTree.Add(27);

            //right, left rotate
            avlTree.Add(70);
            avlTree.Add(60);

            //parent rotations
            avlTree.Add(80);

            Assert.True(TestUtils.AreEqual(avlTree.GetRoot(), referenceTree));
        }

        [Fact]
        public void AVLTreeFindsKeyValuePair()
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