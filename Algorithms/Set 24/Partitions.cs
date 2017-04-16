using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_24
{
    public static class Partitions
    {
        private const long Mod = 1000000007;

        public static long Solve(string s, long m)
        {
            long current = 0;
            long count = 0;

            for (int i =0;i<s.Length;i++)
            {
                current = ((current * 10) % m + s[i] - '0') % m;

                if (current ==0)
                {
                    count++;
                }
            }

            if (current != 0 || count == 0)
            {
                return 0;
            }

            return Power(count - 1);
        }

        private static long Power(long pwr)
        {
            if (pwr == 0)
            {
                return 1;
            }

            long result = Power(pwr / 2);
            result = (result * result) % Mod;

            if (pwr % 2==1)
            {
                result = (result * 2) % Mod;
            }

            return result;
        }
    }

    [TestClass]
    public class PartitionsTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(0, Partitions.Solve("44", 3));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(0, Partitions.Solve("10000", 7));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(4, Partitions.Solve("123", 1));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(32, Partitions.Solve("333333", 3));
        }
    }
}
