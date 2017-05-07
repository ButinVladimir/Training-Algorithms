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
            Assert.AreEqual(6, LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 0, 0, 1, 0, 0, 0 };
            Assert.AreEqual(6, LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = new int[] { 1, 1, 1, 0, 0, 0, 0 };
            Assert.AreEqual(7, LongestSubarray.Solve(a));
        }

        [TestMethod]
        public void Test4()
        {
            int[] a = new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0 };
            Assert.AreEqual(7, LongestSubarray.Solve(a));
        }
    }
}
