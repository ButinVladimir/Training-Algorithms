using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_27
{
    public static class Balancing
    {
        public static long Solve(long[] a, int n)
        {
            Array.Sort(a);
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i];
            }

            long md = sum % n;
            long div = sum / n;
            long diff = 0;
            long next;

            for (int i = n - 1; i >= 0; i--)
            {
                next = md == 0 ? div : div + 1;
                md = md > 0 ? md - 1 : 0;

                diff += Math.Abs(next - a[i]);
            }

            return diff / 2;
        }
    }

    [TestClass]
    public class BalancingTest
    {
        [TestMethod]
        public void Test1()
        {
            long[] a = new long[] { 1, 6 };
            int n = a.Length;

            Assert.AreEqual(2, Balancing.Solve(a, n));
        }

        [TestMethod]
        public void Test2()
        {
            long[] a = new long[] { 10, 11, 10, 11, 10, 11, 11 };
            int n = a.Length;

            Assert.AreEqual(0, Balancing.Solve(a, n));
        }

        [TestMethod]
        public void Test3()
        {
            long[] a = new long[] { 1, 2, 3, 4, 5 };
            int n = a.Length;

            Assert.AreEqual(3, Balancing.Solve(a, n));
        }
    }
}
