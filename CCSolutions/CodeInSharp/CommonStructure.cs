using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeInSharp
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public int Value;

        public BinaryTreeNode() { }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }

    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", X, Y);
        }
    }
}
