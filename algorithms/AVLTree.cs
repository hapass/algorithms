using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Node
    {
        public int Height {
            get {
                if (height != -1)
                {
                    return height;
                }

                if (Left == null || Right == null)
                {
                    return -1;
                }

                if (Left.Height > Right.Height)
                {
                    return Left.Height + 1;
                }

                return Right.Height + 1;
            }
        }

        public int Key = 0;
        public string Value = null;
        public Node Left = null;
        public Node Right = null;
        public Node Parent = null;

        private int height = -1;

        public Node(Node parent = null)
        {
            this.Parent = parent;
        }

        public Node(int height)
        {
            this.height = height;
        }
    }

    public class AVLTree
    {
        private Node treeRoot = new Node();

        public Node GetRoot()
        {
            return treeRoot;
        }

        public bool Add(int key, string value = null)
        {
            Node subtreeRoot = treeRoot;
            Node node = null;

            while (true)
            {
                if (subtreeRoot.Height == -1)
                {
                    node = subtreeRoot;
                    break;
                }

                if (key == subtreeRoot.Key)
                {
                    return false;
                }

                if (key < subtreeRoot.Key)
                {
                    subtreeRoot = subtreeRoot.Left;
                }
                else
                {
                    subtreeRoot = subtreeRoot.Right;
                }
            }

            //add node
            node.Key = key;
            node.Value = value;
            node.Left = new Node(node);
            node.Right = new Node(node);

            Rebalance(node.Parent);
            return true;
        }

        private void Rebalance(Node subtreeRoot)
        {
            if (subtreeRoot == null || subtreeRoot.Height == -1) 
            {
                return;
            }

            int heightDifference = Math.Abs(subtreeRoot.Left.Height - subtreeRoot.Right.Height);

            if (heightDifference > 1)
            {
                /*
                    Comparisons below should work,
                    because if Left.Height is greater than any height it cannot be -1,
                    and thus Left.Left exists. Same thing with Right.Height and Right.Right node.
                */

                if (subtreeRoot.Left.Height > subtreeRoot.Right.Height &&
                    subtreeRoot.Left.Left.Height > subtreeRoot.Left.Right.Height)
                {
                    Console.WriteLine("rotate - right");
                    RotateRight(subtreeRoot);
                }

                if (subtreeRoot.Left.Height > subtreeRoot.Right.Height &&
                    subtreeRoot.Left.Right.Height > subtreeRoot.Left.Left.Height)
                {
                    Console.WriteLine("rotate - left - right");
                    RotateLeft(subtreeRoot.Left);
                    RotateRight(subtreeRoot);
                }

                if (subtreeRoot.Right.Height > subtreeRoot.Left.Height &&
                    subtreeRoot.Right.Right.Height > subtreeRoot.Right.Left.Height)
                {
                    Console.WriteLine("rotate - left");
                    RotateLeft(subtreeRoot);
                }

                if (subtreeRoot.Right.Height > subtreeRoot.Left.Height &&
                    subtreeRoot.Right.Left.Height > subtreeRoot.Right.Right.Height)
                {
                    Console.WriteLine("rotate - right - left");
                    RotateRight(subtreeRoot.Right);
                    RotateLeft(subtreeRoot);
                }
            }

            Rebalance(subtreeRoot.Parent);
        }

        private void RotateRight(Node node)
        {
            if (node.Parent == null)
            {
                treeRoot = node.Left;
            }
            else if (node.Parent.Left == node)
            {
                node.Parent.Left = node.Left;
            }
            else if (node.Parent.Right == node)
            {
                node.Parent.Right = node.Left;
            }

            node.Left.Parent = node.Parent;
            node.Parent = node.Left;

            Node nodeLeftRight = node.Left.Right;
            node.Left.Right = node;
            node.Left = nodeLeftRight;
        }

        private void RotateLeft(Node node)
        {
            if (node.Parent == null)
            {
                treeRoot = node.Right;
            }
            else if (node.Parent.Left == node)
            {
                node.Parent.Left = node.Right;
            }
            else if (node.Parent.Right == node)
            {
                node.Parent.Right = node.Right;
            }

            node.Right.Parent = node.Parent;
            node.Parent = node.Right;

            Node nodeRightLeft = node.Right.Left;
            node.Right.Left = node;
            node.Right = nodeRightLeft;
        }

        public Node Find(int key)
        {
            return Find(key, treeRoot);
        }

        private Node Find(int key, Node subtreeRoot)
        {
            if (subtreeRoot.Height == -1)
            {
                return null;
            }

            if (key < subtreeRoot.Key)
            {
                return Find(key, subtreeRoot.Left);
            }

            if (key > subtreeRoot.Key)
            {
                return Find(key, subtreeRoot.Right);
            }

            return subtreeRoot;
        }

        private Node FindMin(Node subtreeRoot)
        {
            if (subtreeRoot.Height == -1)
            {
                return subtreeRoot.Parent;
            }

            return FindMin(subtreeRoot.Left);
        }

        public bool Delete(int key)
        {
            Node node = Find(key);

            if (node == null)
            {
                return false;
            }

            if (node.Left.Height == -1 && node.Right.Height == -1)
            {
                node.Key = 0;
                node.Value = null;
                node.Left = null;
                node.Right = null;
            }
            else if (node.Left.Height == -1 && node.Right.Height != -1)
            {
                node.Key = node.Right.Key;
                node.Value = node.Right.Value;
                node.Left = node.Right.Left;
                node.Right = node.Right.Right;
            }
            else if (node.Right.Height == -1 && node.Left.Height != -1)
            {
                node.Key = node.Left.Key;
                node.Value = node.Left.Value;
                node.Left = node.Left.Left;
                node.Right = node.Left.Right;
            }
            else if (node.Right.Height != -1 && node.Left.Height != -1)
            {
                Node successor = FindMin(node.Right);
                Delete(successor.Key);
                node.Key = successor.Key;
                node.Value = successor.Value;
            }

            Rebalance(node);

            return true;
        }

        public List<string> Sort()
        {
            throw new NotImplementedException();
        }
    }
}