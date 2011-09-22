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
            Stack<int> s1 = new Stack<int>(new []{ 2, 3, 5, 9, 7, 1 });
            Stack<int> s2 = new Stack<int>();
            UseTwoStacksToSort_Impl(s1, s2);
            while(s2.Count > 0) // when iterate stack, don't use for loop, use while loop.
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
            Assert.IsTrue(IsBalancedTree(tree1));

            BinaryTreeNode tree2 = new BinaryTreeNode()
            {
                Left = new BinaryTreeNode() { Left = new BinaryTreeNode() { Left = new BinaryTreeNode()} },
                Right = new BinaryTreeNode(),
            };
            Assert.IsFalse(IsBalancedTree(tree2));
        }

        public bool IsBalancedTree(BinaryTreeNode tree)
        {
            int temp = -1;
            foreach (var n in TraverseLeafNode(tree, 0))
            {
                Console.WriteLine(n);
                if (temp > 0 && Math.Abs(temp - n) >= 2)
                {
                    return false;
                }
                temp = n;
            }
            return true;
        }

        public IEnumerable<int> TraverseLeafNode(BinaryTreeNode tree, int depth)
        {
            if (tree.Left != null)
            {
                foreach (var t in TraverseLeafNode(tree.Left, depth + 1))
                {
                    yield return t;
                }
            }
            if (tree.Right != null)
            {
                foreach (var t in TraverseLeafNode(tree.Right, depth + 1))
                {
                    yield return t;
                }
            }
            if (tree.Left == null && tree.Right == null)
            {
                yield return depth;
            }
        }
    }
}
