using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeInSharp;

namespace CareerCupCSharp
{
    [TestClass]
    public class Array
    {
        /// <summary>
        /// Design an algorithm and write code to remove the duplicate 
        /// characters in a string without using any additional buffer. 
        /// http://www.careercup.com/question?id=2869
        /// </summary>
        [TestMethod]
        public void Question2_RemoveDupCharInString()
        {
            string input = "abcioachdyeeq";
            string output = RemoveDupCharInString(input);
            Console.WriteLine(output);
            input = "abcabciiiiioop";
            output = RemoveDupCharInString(input);
            Console.WriteLine(output);
        }

        private string RemoveDupCharInString(string input)
        {
            var arr = input.ToArray();
            int length = arr.Length;
            // declare 3 pointers, comparer, write, read
            int comparer = 0;
            while (comparer < length)
            {
                int write = comparer + 1;
                int copyLength = length;
                for (int read = comparer + 1; read < copyLength; read++)
                {
                    if (arr[comparer] != arr[read]) // not equal, both read and write ++, write write
                    {
                        arr[write++] = arr[read];
                    }
                    else // read++, write not changed, total length - 1
                    {
                        length--;
                    }
                }
                comparer++;
            }
            return new string(arr.Take(length).ToArray());
        }

        // TODO: remove dup words in string
    }
}
