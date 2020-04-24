using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreePerformsLeftRightTurn()
        {
            Node referenceTree = new Node(0) {
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
                    Key = 40,
                    Left = new Node(0) {
                        Key = 27,
                        Left = new Node(0) {
                            Key = 25
                        },
                        Right = new Node(0) {
                            Key = 30
                        }
                    },
                    Right = new Node(0) {
                        Key = 50
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
            avlTree.Add(25);
            avlTree.Add(27);

            Assert.True(TestUtils.AreEqual(avlTree.GetRoot(), referenceTree));
        }
    }
}