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

            Node parentNode = node.Parent;
            while (parentNode != null)
            {
                int heightDifference = Math.Abs(parentNode.Left.Height - parentNode.Right.Height);

                if (heightDifference > 1)
                {
                    /*
                        Comparisons below should work,
                        because if Left.Height is greater than any height it cannot be -1,
                        and thus Left.Left exists. Same thing with Right.Height and Right.Right node.
                    */

                    if (parentNode.Left.Height > parentNode.Right.Height &&
                        parentNode.Left.Left.Height > parentNode.Left.Right.Height)
                    {
                        Console.WriteLine("rotate - right");
                        RotateRight(parentNode);
                    }

                    if (parentNode.Left.Height > parentNode.Right.Height &&
                        parentNode.Left.Right.Height > parentNode.Left.Left.Height)
                    {
                        Console.WriteLine("rotate - left - right");
                        RotateLeft(parentNode.Left);
                        RotateRight(parentNode);
                    }

                    if (parentNode.Right.Height > parentNode.Left.Height &&
                        parentNode.Right.Right.Height > parentNode.Right.Left.Height)
                    {
                        Console.WriteLine("rotate - left");
                        RotateLeft(parentNode);
                    }

                    if (parentNode.Right.Height > parentNode.Left.Height &&
                        parentNode.Right.Left.Height > parentNode.Right.Right.Height)
                    {
                        Console.WriteLine("rotate - right - left");
                        RotateRight(parentNode.Right);
                        RotateLeft(parentNode);
                    }
                }

                parentNode = parentNode.Parent;
            }

            return true;
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

        public bool Delete(int key)
        {
            Node node = Find(key);

            if (node == null)
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public List<string> Sort()
        {
            throw new NotImplementedException();
        }
    }
}