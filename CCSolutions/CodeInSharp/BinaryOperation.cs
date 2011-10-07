using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeInSharp;

namespace CareerCupCSharp
{
    [TestClass]
    public class BinaryOperation
    {
        /// <summary>
        /// Write a function int BitSwapReqd(int A, int B) to determine the 
        /// number of bits required to convert integer A to integer B. 
        /// http://www.careercup.com/question?id=2880 
        /// </summary>
        [TestMethod]
        public void Question1_BitSwapRequired()
        {
            int a = 7; // 111
            int b = 11; // 1011 
            Console.WriteLine(BitSwapRequired(a, b));
        }

        private int BitSwapRequired(int a, int b)
        {
            // A XOR B, then count 1's in the number
            int xor = a ^ b;
            int result = 0;
            while (xor != 0)
            {
                if ((xor & 1) == 1)
                {
                    result++;
                }
                xor = xor >> 1;
            }
            return result;
        }

        /// <summary>
        /// If you were to write a program to swap odd and even bits in 
        /// integer, what is the minimum number of instructions required? 
        /// (eg, bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, etc) 
        /// EXAMPLE: 
        /// Input: 10001010 
        /// Output: 01000101  
        /// http://www.careercup.com/question?id=2906 
        /// </summary>
        [TestMethod]
        public void Question2_BitSwapEvenOdd()
        {
            int input = 138; // 10001010
            Console.WriteLine("input = " + Convert.ToString(input, 2)); // c# method: output binary format 
            int output = BitSwapEvenOdd(input);
            Console.WriteLine("output = " + Convert.ToString(output, 2));
        }
        
        private int BitSwapEvenOdd(int input)
        {
            // get the odd bits by input & 010101010101;
            // get the even bits by input & 101010101010;
            int odd = input & 0x555555;
            int even = input & 0xAAAAAA;
            // odd << 1, even >> 1
            return (odd << 1) | (even >> 1);
        }
    }
}
