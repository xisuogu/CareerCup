using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerCupCSharp
{
    [TestClass]
    public class AppliedMath
    {
        /// <summary>
        /// Write a method to generate the nth Fibonacci number. 
        /// http://www.careercup.com/question?id=1453
        /// </summary>
        [TestMethod]
        public void Question1_Fibonacci()
        {
            int count = 0;
            foreach (var fib in Fib())
            {
                if (count++ > 10)
                {
                    return;
                }
                Console.WriteLine(fib);
            }
        }

        public IEnumerable<int> Fib()
        {
            int a = 0;
            int b = 1;
            while (true)
            {
                yield return a;
                int tmp = a;
                a = b + a;
                b = tmp;
            }
        }

        /// <summary>
        /// Write a method to count the number of 2's between 0 and n. 
        /// EXAMPLE 
        /// input: 35 
        /// output: 14 [list of 2's: 2, 12, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 
        /// 32]  
        ///   http://www.careercup.com/question?id=56794 
        /// </summary>
        [TestMethod]
        public void Question2_Count2()
        {
            // brute force parse string
            Console.WriteLine(Count2_Method1(35));
        }

        private int Count2_Method1(int input)
        {
            return Enumerable.Range(1, input).Sum(n => n.ToString().Count(c => c == '2'));
        }

        /// <summary>
        /// Write an algorithm which computes the number of trailing ze-ros in n factorial. 
        /// EXAMPLE 
        /// input: 11 
        /// output: 2 (11! = 39916800) 
        ///   http://www.careercup.com/question?id=2577
        /// </summary>
        [TestMethod]
        public void Question5_Count_Trailing_Zero()
        {
            // brute-force, get the factorial and count
            Console.WriteLine(Count_Trailing_Zero_Method1(11));
            // count from 1, if a number can be devided by 5, it would introduce 1 '0'
            // before '5', there must be a 2, and '10' has 1 '5', 100 has 2 '5'
            Console.WriteLine(Count_Trailing_Zero_Method2(11));
        }

        private int Count_Trailing_Zero_Method1(int number)
        {
            var num = Enumerable.Range(1, number).Aggregate((a, b) => a * b);
            int ans = 0;
            while (num % 10 == 0)
            {
                ans += 1;
                num /= 10;
            }
            return ans;
        }

        private int Count_Trailing_Zero_Method2(int number)
        {
            int ans = 0;
            for (int i = 5; i <= number; i++)
            {
                int j = i;
                while (j % 5 == 0)
                {
                    j /= 5;
                    ans++;
                }
            }
            return ans;
        }

        /// <summary>
        /// Write a function that adds two numbers. You should not use + 
        /// or any arithmetic operators. 
        /// http://www.careercup.com/question?id=57210
        /// </summary>
        [TestMethod]
        public void Question5_Add_without_using_Add()
        {
            // method1: using string to hack around
            Console.WriteLine(Add_without_using_Add_Method1(5, 6));
            // method2: tricky add !!
            //   step1: a bit add b, without carry, can use xor ^ to do, 1+1=0, 0+0=1， 1+0=1
            //   step2: compute carry, use bit and, then left shift
            //   step3: recursively add result of step1, step2, if step2 result is 0, then means it is ok to return.
            Console.WriteLine(Add_without_using_Add_Method2(5, 6));
        }

        private int Add_without_using_Add_Method1(int a, int b)
        {
            string stra = new string(' ', a);
            string strb = new string(' ', b);
            string strc = stra + strb;
            return strc.Length;
        }

        private int Add_without_using_Add_Method2(int a, int b)
        {
            int tmpA = a ^ b;
            int tmpB = (a & b) << 1;
            if (tmpB == 0)
            {
                return tmpA;
            }
            return Add_without_using_Add_Method2(tmpA, tmpB);
        }

        /// <summary>
        /// Write a method to implement *, - , / operations.  You should 
        /// use only the + operator.  
        /// http://www.careercup.com/question?id=1391
        /// </summary>
        [TestMethod]
        public void Question6_Mul_Div_Minus_using_Add()
        {
            int a = 11;
            int b = 3;
            // *, for loop
            int resultMul = 0;
            for (int i = 0; i < a; i++)
            {
                resultMul += b;
            }
            Console.WriteLine(resultMul);
            // -, still using for
            int resultMinus = 0;
            for (int i = b; i < a; i++)
            {
                resultMinus += 1;
            }
            Console.WriteLine(resultMinus);
            // /
            int resultDiv = 0;
            while ((resultDiv + 1) * b < a)
            {
                resultDiv++;
            }
            Console.WriteLine(resultDiv);
        }

        /// <summary>
        /// Design an algorithm to find the kth number divisible by only 3
        /// or 5 or 7.  That is, the only factors of these numbers should be 
        /// 3,5 and 7.  
        /// http://www.careercup.com/question?id=57139
        /// </summary>
        [TestMethod]
        public void Question7_Kth_3_5_7()
        {
            // a fast approach
            // not 2, means half of the number is not the correct ones
            // so probe start from 2 * K = N
            // only divided by 3 number = N / 3
            // only divided by 5 number = N / 5, and N/7
            // divied only by 3, 5 = N / 15, and N / 21, N / 35
            // divided by 3, 5, 7, N / 105
            // three circles, A + B + C - AB - AC - BC + ABC
            for (int i = 1; i < 20; i++)
            {
                Console.WriteLine(Kth_3_5_7(i));
            }
        }

        private int Kth_3_5_7(int k)
        {
            int probe = 2 * k + 1;
            while (true)
            {
                int a = probe / 3;
                int b = probe / 5;
                int c = probe / 7;
                int ab = probe / 15;
                int bc = probe / 35;
                int ac = probe / 21;
                int abc = probe / 105;
                int realResultOfProbe = a + b + c - ab - ac - bc + abc;
                if (realResultOfProbe < k)
                {
                    probe += k - realResultOfProbe;
                }
                else
                {
                    return probe;
                }
            }
        }
    }
}
