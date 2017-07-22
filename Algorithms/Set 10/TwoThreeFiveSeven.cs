using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_10
{
    public static class TwoThreeFiveSeven
    {
        private static readonly long[] mods = { 2, 3, 5, 7 };

        public static long[] Solve(int n)
        {
            SortedSet<long> list = new SortedSet<long>();
            list.Add(1);

            List<long> result = new List<long>();
            for (int i = 0; i < n; i++)
            {
                long value = list.First();

                result.Add(value);
                list.Remove(value);

                foreach (long mod in mods)
                {
                    long nextValue = value * mod;
                    if (!list.Contains(nextValue))
                    {
                        list.Add(nextValue);
                    }
                }

                while (list.Count > n - i - 1)
                {
                    list.Remove(list.Last());
                }
            }

            return result.ToArray();
        }
    }

    [TestClass]
    public class TwoTest
    {
        [TestMethod]
        public void Test()
        {
            int n = 5;

            long[] expected = { 1, 2, 3, 4, 5 };
            long[] actual = TwoThreeFiveSeven.Solve(n);

            this.Compare(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            int n = 15;

            long[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16, 18 };
            long[] actual = TwoThreeFiveSeven.Solve(n);

            this.Compare(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            int n = 1000005;

            TwoThreeFiveSeven.Solve(n);
        }

        private void Compare(long[] expected, long[] actual)
        {
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
