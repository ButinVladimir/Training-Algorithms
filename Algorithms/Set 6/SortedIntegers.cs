using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_6
{
    public static class SortedIntegers
    {
        public static Tuple<int, int> Solve(int[][] arrays)
        {
            int n = arrays.Length;
            SortedSet<Tuple<int, int>> set = new SortedSet<Tuple<int, int>>();
            int[] positions = new int[n];
            int max = arrays[0][0];

            for (int i = 0; i < n; i++)
            {
                max = Math.Max(arrays[i][0], max);
                set.Add(new Tuple<int, int>(arrays[i][0], i));
            }

            Tuple<int, int> result = null;

            while (true)
            {
                Tuple<int, int> first = set.First();
                set.Remove(first);

                int min = first.Item1;
                if (result == null || max - min < result.Item2 - result.Item1)
                {
                    result = new Tuple<int, int>(min, max);
                }

                int arrayIndex = first.Item2;
                int position = ++positions[arrayIndex];

                if (position >= arrays[arrayIndex].Length)
                {
                    break;
                }

                set.Add(new Tuple<int, int>(arrays[arrayIndex][position], arrayIndex));
                max = Math.Max(arrays[arrayIndex][position], max);
            }

            return result;
        }
    }

    [TestClass]
    public class SortedIntegersTest
    {
        [TestMethod]
        public void Test()
        {
            int[][] arrays = new int[][]
            {
                new int[] { 4, 10, 15, 24, 26 },
                new int[] { 0, 9, 12, 20 },
                new int[] { 5, 18, 22, 30 },
            };

            Assert.AreEqual(new Tuple<int, int>(20, 24), SortedIntegers.Solve(arrays));
        }
    }
}
