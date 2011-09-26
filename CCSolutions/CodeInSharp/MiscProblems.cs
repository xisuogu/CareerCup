using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeInSharp
{
    [TestClass]
    public class MiscProblems
    {
        /// <summary>
        /// One stack has the list of numbers, there is another stack,
        /// put the numbers to 2nd stack, make them sorted
        /// </summary>
        [TestMethod]
        public void UseTwoStackToSort()
        {
            Stack<int> s1 = new Stack<int>(new[] { 2, 3, 5, 9, 7, 1 });
            Stack<int> s2 = new Stack<int>();
            UseTwoStacksToSort_Impl(s1, s2);
            while (s2.Count > 0) // when iterate stack, don't use for loop, use while loop.
            {
                Console.WriteLine(s2.Pop());
            }
            Assert.AreEqual(0, s1.Count);
        }

        private void UseTwoStacksToSort_Impl(Stack<int> stack1, Stack<int> stack2)
        {
            if (stack1.Count == 0)
            {
                return;
            }
            stack2.Push(stack1.Pop());
            while (stack1.Count > 0)
            {
                int temp = stack1.Pop();
                if (temp > stack2.Peek()) // if directly move is not sorted, swap the s2 elements to s1.
                {
                    int s2Count = stack2.Count;
                    for (int i = 0; i < s2Count; i++)
                    {
                        stack1.Push(stack2.Pop());
                    }
                }
                stack2.Push(temp);
            }
        }

        [TestMethod]
        public void SeeIfATreeIsBalancedTree()
        {
            BinaryTreeNode tree1 = new BinaryTreeNode()
            {
                Left = new BinaryTreeNode() { Left = new BinaryTreeNode() },
            };
            Assert.IsFalse(IsBalancedTree(tree1));

            BinaryTreeNode tree2 = new BinaryTreeNode()
            {
                Left = new BinaryTreeNode() { Left = new BinaryTreeNode() { Left = new BinaryTreeNode() } },
                Right = new BinaryTreeNode(),
            };
            Assert.IsFalse(IsBalancedTree(tree2));

            BinaryTreeNode tree3 = new BinaryTreeNode()
            {
                Left = new BinaryTreeNode() { Left = new BinaryTreeNode() },
                Right = new BinaryTreeNode() { Left = new BinaryTreeNode() },
            };
            Assert.IsTrue(IsBalancedTree(tree3));
        }

        public bool IsBalancedTree(BinaryTreeNode tree)
        {
            return MaxTreeDepth(tree) - MinTreeDepth(tree) <= 1;
        }

        /// <summary>
        /// !!!!! To recite, get the max depth of the tree
        /// </summary>
        public int MaxTreeDepth(BinaryTreeNode tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxTreeDepth(tree.Left), MaxTreeDepth(tree.Right));
        }

        public int MinTreeDepth(BinaryTreeNode tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return 1 + Math.Min(MinTreeDepth(tree.Left), MinTreeDepth(tree.Right));
        }

        /// <summary>
        /// Given a binary tree, traverse the tree layer by layer
        /// </summary>
        [TestMethod]
        public void TraverseTreeInDepthOrder()
        {
            BinaryTreeNode tree3 = new BinaryTreeNode(1)
            {
                Left = new BinaryTreeNode(2) { Left = new BinaryTreeNode(4), Right = new BinaryTreeNode(5) },
                Right = new BinaryTreeNode(3) { Left = new BinaryTreeNode(6), Right = new BinaryTreeNode(7) },
            };
            // create a queue
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(tree3);
            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                Console.WriteLine(t.Value);
                if (t.Left != null)
                {
                    queue.Enqueue(t.Left);
                }
                if (t.Right != null)
                {
                    queue.Enqueue(t.Right);
                }
            }
        }
    }
}
