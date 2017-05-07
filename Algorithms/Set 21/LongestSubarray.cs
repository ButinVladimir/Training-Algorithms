using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_21
{
    public static class LongestSubarray
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int nn = a.Length + 2;

            int[] negativePositions = new int[nn];
            for (int i = 0; i < nn; i++)
            {
                negativePositions[i] = -1;
            }

            int current = 0;
            for (int position = 0; position < a.Length; position++)
            {
                if (a[position] == 0)
                {
                    current++;
                }
                else
                {
                    current--;
                }

                if (current > 0)
                {
                    result = Math.Max(result, position + 1);
                }
                else
                {
                    if (negativePositions[-current] == -1)
                    {
                        negativePositions[-current] = position;
                    }

                    if (negativePositions[-current + 1] != -1)
                    {
                        result = Math.Max(result, position - negativePositions[-current + 1]);
                    }
                }
            }

            return result;
        }

        public static int BruteSolve(int[] a)
        {
            int result = 0;
            int current;

            for (int start = 0; start < a.Length; start++)
            {
                current = 0;
                for (int length = 0; start + length < a.Length; length++)
                {
                    if (a[start + length] == 0)
                    {
                        current++;
                    }
                    else
                    {
                        current--;
                    }

                    if (current > 0)
                    {
                        result = Math.Max(result, length + 1);
                    }
                }
            }

            return result;
        }
    }

    [TestClass]
    public class LongestSubarrayTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 0, 0, 0, 0, 0, 0 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 0, 0, 1, 0, 0, 0 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = new int[] { 1, 1, 1, 0, 0, 0, 0 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test4()
        {
            int[] a = new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test5()
        {
            int[] a = new int[] { 1, 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test6()
        {
            int[] a = new int[] { 1, 0, 1, 0, 1, 0, 1 };
            Assert.AreEqual(LongestSubarray.BruteSolve(a), LongestSubarray.Solve(a));
        }
    }
}
