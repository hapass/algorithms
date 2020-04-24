using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreePerformsLeftStraightTurn()
        {
            Node referenceTree = new Node() {
                Key = 20,
                Height = 0,
                Left = new Node() {
                    Key = 10,
                    Height = 0
                },
                Right = new Node {
                    Key = 30,
                    Height = 0
                }
            };

            var avlTree = new AVLTree();
            avlTree.Add(10);
            avlTree.Add(20);
            avlTree.Add(30);

            Assert.True(TestUtils.AreEqual(avlTree.GetRoot(), referenceTree));
        }

        [Fact]
        public void AVLTreePerformsTurnOnSubtree()
        {
            Node referenceTree = new Node() {
                Key = 20,
                Height = 0,
                Left = new Node {
                    Key = 10,
                    Height = 0
                },
                Right = new Node {
                    Key = 40,
                    Height = 0,
                    Left = new Node {
                        Key = 30,
                        Height = 0
                    },
                    Right = new Node {
                        Key = 50,
                        Height = 0
                    }
                }
            };

            var avlTree = new AVLTree();
            avlTree.Add(10);
            avlTree.Add(20);
            avlTree.Add(30);
            avlTree.Add(40);
            avlTree.Add(50);

            Assert.True(TestUtils.AreEqual(avlTree.GetRoot(), referenceTree));
        }

        [Fact]
        public void AVLTreePerformsRightStraightTurn()
        {
            Node referenceTree = new Node() {
                Key = 20,
                Height = 0,
                Left = new Node {
                    Key = 5,
                    Height = 0,
                    Left = new Node {
                        Key = 1,
                        Height = 0
                    },
                    Right = new Node {
                        Key = 10,
                        Height = 0
                    }
                },
                Right = new Node {
                    Key = 40,
                    Height = 0,
                    Left = new Node {
                        Key = 30,
                        Height = 0
                    },
                    Right = new Node {
                        Key = 50,
                        Height = 0
                    }
                }
            };

            var avlTree = new AVLTree();
            avlTree.Add(10);
            avlTree.Add(20);
            avlTree.Add(30);
            avlTree.Add(40);
            avlTree.Add(50);
            avlTree.Add(5);
            avlTree.Add(1);

            Assert.True(TestUtils.AreEqual(avlTree.GetRoot(), referenceTree));
        }
    }
}