using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_21
{
    public static class Search
    {
        public static int? Solve(int[] a, int val)
        {
            if (!Check(a))
            {
                throw new ArgumentException("Array is not valid");
            }

            return Solve(0, a.Length - 1, a, val);
        }

        private static int? Solve(int left, int right, int[] a, int val)
        {
            if (left > right)
            {
                return null;
            }

            if (a[left] == val)
            {
                return left;
            }

            if (a[right] == val)
            {
                return right;
            }

            if (right - left <= 1 || Math.Abs(val - a[left]) + Math.Abs(val - a[right]) > right - left)
            {
                return null;
            }

            int m = (left + right) / 2;
            int? result = Solve(left, m, a, val);

            if (result != null)
            {
                return result;
            }

            return Solve(m + 1, right, a, val);
        }

        private static bool Check(int[] a)
        {
            if (a == null)
            {
                return false;
            }

            for (int i = 1; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - a[i - 1]) > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }

    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { -1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 1, 0, -1 };

            Assert.IsTrue(Check(a, 3));
            Assert.IsTrue(Check(a, -3));
            Assert.IsTrue(Check(a, 2));
            Assert.IsTrue(Check(a, -1));
            Assert.IsTrue(Check(a, 1));
            Assert.IsTrue(Check(a, 0));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            Assert.IsTrue(Check(a, 1));
            Assert.IsTrue(Check(a, 2));
            Assert.IsTrue(Check(a, 3));
            Assert.IsTrue(Check(a, 4));
            Assert.IsTrue(Check(a, 5));
            Assert.IsTrue(Check(a, 6));
        }

        private bool Check(int[] a, int val)
        {
            int? result = Search.Solve(a, val);

            if (result == null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == val)
                    {
                        return false;
                    }
                }

                return true;
            }

            return result >= 0 && result < a.Length && a[(int)result] == val;
        }
    }
}
