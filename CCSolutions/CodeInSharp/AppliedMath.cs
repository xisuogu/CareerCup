using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeInSharp;

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
        public void Question6_Add_without_using_Add()
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
        public void Question7_Mul_Div_Minus_using_Add()
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
        public void Question8_Kth_3_5_7()
        {
            // make 3 queues, put 3, 5, 7 into them.
            // next value = min(3queues)
            // after got a value = n:
            //   if value is from 3's queue, enqueue 3*n, 5*n, 7*n to 3 queues
            //   if value is from 5's queue, enqueue 5*n, 7*n to 5/7 queues
            //   if value is from 7's queue, enqueue 7*n, to 7 queue
            //   there is no need to enqueue 3*n to 3 queue, when n is from 5
            //   because (n / 5 * 3) must be enqueued together with n, and it is smaller than n,
            //   so that it would be already a previous number, when it is out, (n/5*3 *5) = 3*n is already enqueue to 5 queue
            //   no need to enqueue again.
            foreach (int a in Kth_3_5_7())
            {
                if (a > 500)
                {
                    break;
                }
                Console.WriteLine(a);
            }
        }

        private IEnumerable<int> Kth_3_5_7()
        {
            Queue<int> q3 = new Queue<int>();
            Queue<int> q5 = new Queue<int>();
            Queue<int> q7 = new Queue<int>();
            q3.Enqueue(3);
            q5.Enqueue(5);
            q7.Enqueue(7);
            while (true)
            {
                int value = Math.Min(q7.Peek(), Math.Min(q3.Peek(), q5.Peek()));
                yield return value;
                if (value == q3.Peek())
                {
                    q3.Dequeue();
                    q3.Enqueue(value * 3);
                    q5.Enqueue(value * 5);
                    q7.Enqueue(value * 7);
                }
                if (value == q5.Peek())
                {
                    q5.Dequeue();
                    q5.Enqueue(value * 5);
                    q7.Enqueue(value * 7);
                }
                if (value == q7.Peek())
                {
                    q7.Dequeue();
                    q7.Enqueue(value * 7);
                }
            }
        }

        /// <summary>
        /// Input(ht wt) : (65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110) , (69, 99), (76, 180)
        /// Output: The longest tower is length 6 and includes from top to 
        /// bottom: (56,90) (60,95) (65,100) (68,110) (70,150) (75,190) 
        /// Rule: next(a).x > a.x, next(a).y > a.y, given a set of point, get the longest line
        /// http://www.careercup.com/question?id=2667
        /// </summary>
        /// !!!!! LIS (longest increasing subsequence), important !!!
        [TestMethod]
        public void Question9_Two_Dimension_Sort()
        {
            Point[] input = new Point[] {new Point(56, 90), new Point(60, 95),  new Point(65, -10), new Point(68, 99), 
                new Point(69, 110), new Point(70, 100), new Point(75, 0), new Point(76, 180)};
            // step 1, sort by X
            input = input.OrderBy(p => p.X).ToArray();
            // step 2, get the longest increasing subsequence (LIS) in the array, compare Y
            int[] L = new int[input.Length]; // L[i] stores the LIS.length, from input[0] to input[i], LIS ends with input[i]
            // L[0] = 1, L[i] = max(L[k] + 1, 1)  when 0 <= k < i, input[k] < input[i]
            L[0] = 1;
            for (int i = 1; i < input.Length; i++)
            {
                L[i] = 1; // if before data[i], all the element is larger than data[i], the LIS ends with data[i]'s length is only 1
                for (int j = 0; j < i; j++)
                {
                    if (input[i].Y > input[j].Y)
                    {
                        L[i] = Math.Max(L[i], L[j] + 1);
                    }
                }
            }
            // output: now we get a L[input.lenght] result, reverse enumerate
            int max = L.Max();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (L[i] == max)
                {
                    Console.WriteLine(input[i]);
                    max--;
                }
            }
        }
    }
}
