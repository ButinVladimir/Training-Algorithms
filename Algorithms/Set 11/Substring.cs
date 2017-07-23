using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_11
{
    public static class Substring
    {
        public static int Solve(string s)
        {
            Dictionary<char, int> prevPosition = new Dictionary<char, int>();

            int left = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (prevPosition.ContainsKey(s[i]))
                {
                    left = Math.Max(left, prevPosition[s[i]] + 1);
                }
                prevPosition[s[i]] = i;

                max = Math.Max(max, i - left + 1);
            }

            return max;
        }
    }

    [TestClass]
    public class SubstringTest
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(5, Substring.Solve("abcde"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(5, Substring.Solve("abadecb"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(3, Substring.Solve("qavvaq"));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(1, Substring.Solve("aaaaaaa"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual(4, Substring.Solve("abdggggta"));
        }
    }
}
