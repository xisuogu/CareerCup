using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeInSharp;

namespace CareerCupCSharp
{
    [TestClass]
    public class CountingCombination
    {
        /// <summary>
        /// Write a method to compute all permutations of a string.  
        /// http://www.careercup.com/question?id=2267
        /// </summary>
        [TestMethod]
        public void Question3_Permute_in_String()
        {
            // method 1, recursive + position noting
            string input = "abcd";
            var outputs = Permute(input.ToCharArray());
            outputs.ToList().ForEach(o => Console.WriteLine(new string(o)));
            Console.WriteLine("===============");
            outputs = Permute(input.ToCharArray(), 3);
            outputs.ToList().ForEach(o => Console.WriteLine(new string(o)));
            Console.WriteLine("===============");
            int[] inputInt = new int[] { 1, 1, 2 };
            var outputsInt = Permute(inputInt);
            outputsInt.ToList().ForEach(o => Console.WriteLine(string.Join(" ", o)));
            Console.WriteLine("===============");
            // method 2, recursive + swap
            input = "ABCD";
            outputs = PermuteSwap(input.ToCharArray());
            outputs.ToList().ForEach(o => Console.WriteLine(new string(o)));
            Console.WriteLine("===============");
            input = "ABCD";
            outputs = PermuteSwap(input.ToCharArray(), 3);
            outputs.ToList().ForEach(o => Console.WriteLine(new string(o)));
        }

        /// <summary>
        /// Generic Permutation, recursive version
        /// </summary>
        /// <param name="input">source collection</param>
        /// <param name="length">default length = 0, means length = len(input), length must LE len(input)</param>
        /// <returns></returns>
        private IEnumerable<T[]> Permute<T>(T[] input, int length = 0)
        {
            if (length == 0)
            {
                length = input.Count();
            }
            if (length > input.Count())
            {
                throw new ApplicationException("length cannot be bigger than input's len.");
            }
            int[] position = new int[input.Count()]; // position array, index is the index in 'input', value is the position in output
            for (int i = 0; i < position.Length; i++)
            {
                position[i] = -1; // start from all -1, means nothing has got position.
            }
            List<T[]> output = new List<T[]>();
            Visit(position, input, 0, length, output);
            return output;
        }

        private void Visit<T>(int[] position, T[] input, int currentLevel, int endLevel, List<T[]> result)
        {
            if (currentLevel == endLevel)
            {
                T[] newData = new T[endLevel];
                for (int i = 0; i < endLevel; i++)
                {
                    int index = position.ToList().IndexOf(i);
                    newData[i] = input[index];
                }
                result.Add(newData);
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (position[i] == -1) // see if input[i] has already be placed, if not, continue processing, if yes, skip
                {
                    position[i] = currentLevel;
                    Visit(position, input, currentLevel + 1, endLevel, result);
                    position[i] = -1;
                }
            }
        }

        private IEnumerable<T[]> PermuteSwap<T>(T[] input, int length = 0)
        {
            if (length == 0)
            {
                length = input.Count();
            }
            if (length > input.Count())
            {
                throw new ApplicationException("length cannot be bigger than input's len.");
            }
            List<T[]> output = new List<T[]>();
            SwapPerm(input, 0, length, output);
            return output;
        }

        private void SwapPerm<T>(T[] input, int level, int endLevel, List<T[]> output)
        {
            if (level == endLevel)
            {
                output.Add(input.Take(endLevel).ToArray());
                return;
            }
            for (int i = level; i < input.Length; i++)
            {
                Swap(ref input, level, i); // SWAP each element with current "HEAD", then get the rest of the array (level++, right shift)
                SwapPerm(input, level + 1, endLevel, output);
                Swap(ref input, level, i); // SWAP back, so that next swap can start from the beginning
            }
        }

        private void Swap<T>(ref T[] input, int a, int b)
        {
            T tmp = input[a];
            input[a] = input[b];
            input[b] = tmp;
        }

        /// <summary>
        /// Implement an algorithm to print all valid (eg, properly opened 
        /// and closed) combinations of n-pairs of parentheses. 
        /// EXAMPLE: 
        /// input: 3 (eg, 3 pairs of parentheses) 
        /// output: ()()(), ()(()), (())(), ((())) , (()())
        /// http://www.careercup.com/question?id=2103
        /// </summary>
        [TestMethod]
        public void Question3_Permute_Parentheses()
        {
            char[] data = new char[8];
            PermParentheses(4, 0, 0, 0, data);
        }

        private void PermParentheses(int pairCount, int currentPosition, int openLeftCount, int usedLeftCount, char[] data)
        {
            if (currentPosition == pairCount * 2)
            {
                Console.WriteLine(new string(data));
                return;
            }
            if (openLeftCount > 0)
            {
                data[currentPosition] = ')';
                PermParentheses(pairCount, currentPosition + 1, openLeftCount - 1, usedLeftCount, data);
            }
            if (usedLeftCount < pairCount)
            {
                data[currentPosition] = '(';
                PermParentheses(pairCount, currentPosition + 1, openLeftCount + 1, usedLeftCount + 1, data);
            }
        }
    }
}
