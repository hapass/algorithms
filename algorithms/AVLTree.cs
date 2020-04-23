using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Node
    {
        public int Height = -1;
        public int Key = 0;
        public String Value = String.Empty;
        public Node Left = null;
        public Node Right = null;
        public Node Parent = null;

        public Node(Node parent = null)
        {
            this.Parent = parent;
        }
    }

    public class AVLTree
    {
        private Node treeRoot = new Node();

        public bool Add(int key, string value)
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
            node.Height = 0;
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

                    //left heavy straight
                    if (parentNode.Left.Height > parentNode.Right.Height &&
                        parentNode.Left.Left.Height > parentNode.Left.Right.Height)
                    {
                        RotateRight(parentNode);
                    }

                    //left heavy zig-zag
                    if (parentNode.Left.Height > parentNode.Right.Height &&
                        parentNode.Left.Right.Height > parentNode.Left.Left.Height)
                    {
                        RotateLeft(parentNode.Left);
                        RotateRight(parentNode);
                    }

                    //right heavy straight
                    if (parentNode.Right.Height > parentNode.Left.Height &&
                        parentNode.Right.Right.Height > parentNode.Right.Left.Height)
                    {
                        RotateLeft(parentNode);
                    }

                    //right heavy zig-zag
                    if (parentNode.Right.Height > parentNode.Left.Height &&
                        parentNode.Right.Left.Height > parentNode.Right.Right.Height)
                    {
                        RotateRight(parentNode.Right);
                        RotateLeft(parentNode);
                    }
                }

                if (parentNode.Left.Height > parentNode.Right.Height)
                {
                    parentNode.Height = parentNode.Left.Height + 1;
                }
                else
                {
                    parentNode.Height = parentNode.Right.Height + 1;
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

            Node nodeRightLeft = node.Right.Left;
            node.Right.Left = node;
            node.Right = nodeRightLeft;
        }

        private Node FindParent(int key, Node subtreeRoot)
        {
            if (subtreeRoot.Height == -1)
            {
                return subtreeRoot;
            }

            if (key < subtreeRoot.Key)
            {
                return FindParent(key, subtreeRoot.Left);
            }

            if (key > subtreeRoot.Key)
            {
                return FindParent(key, subtreeRoot.Right);
            }

            return null;
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

        public string[] Sort()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}