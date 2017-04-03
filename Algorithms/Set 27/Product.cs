using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_27
{
    public static class Product
    {
        public static long Solve(long[] a)
        {
            int n = a.Length;
            long[] sortedArray = new long[n];
            a.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);

            long result = 1;
            for (int i = 0; i < 3; i++)
            {
                result *= sortedArray[i];
            }

            long buffer;
            for (int takeLeft = 0; takeLeft <= 3; takeLeft++)
            {
                buffer = 1;
                for (int i = 0; i < takeLeft; i++)
                {
                    buffer *= sortedArray[i];
                }

                for (int i = 0; i < 3 - takeLeft; i++)
                {
                    buffer *= sortedArray[n - 1 - i];
                }

                result = Math.Max(result, buffer);
            }

            for (int i = 0; i < n; i++)
            {
                if (sortedArray[i] == 0)
                {
                    result = Math.Max(result, 0);
                }
            }

            return result;
        }
    }

    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Test1()
        {
            long[] a = new long[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(120, Product.Solve(a));
        }

        [TestMethod]
        public void Test2()
        {
            long[] a = new long[] { -1, -2, -3, -4, -5, -6 };
            Assert.AreEqual(-6, Product.Solve(a));
        }

        [TestMethod]
        public void Test3()
        {
            long[] a = new long[] { 1, 2, 0, -2, -2, -3, -4, -5, -6 };
            Assert.AreEqual(60, Product.Solve(a));
        }

        [TestMethod]
        public void Test4()
        {
            long[] a = new long[] { 10, 10, 10, -2, -2, -3, -4, -5, -6 };
            Assert.AreEqual(1000, Product.Solve(a));
        }

        [TestMethod]
        public void Test5()
        {
            long[] a = new long[] { 1, 0, -2 };
            Assert.AreEqual(0, Product.Solve(a));
        }

        [TestMethod]
        public void Test6()
        {
            long[] a = new long[] { 0, -1, -2, -3 };
            Assert.AreEqual(0, Product.Solve(a));
        }

        [TestMethod]
        public void Test7()
        {
            long[] a = new long[] { 0, 1, 1 };
            Assert.AreEqual(0, Product.Solve(a));
        }
    }
}
