using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_1
{
    public static class Unpaired
    {
        public static int Solve(int[] a)
        {
            int result = 0;

            foreach (int value in a)
            {
                result ^= value;
            }

            return result;
        }
    }

    [TestClass]
    public class UnpairedTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 2, 2, 3, 3, 4, 4, 5 };

            Assert.AreEqual(5, Unpaired.Solve(a));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 2, 3, 5, 6, 1, 4 };

            Assert.AreEqual(7, Unpaired.Solve(a));
        }
    }
}
