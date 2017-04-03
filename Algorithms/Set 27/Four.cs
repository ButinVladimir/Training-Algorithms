using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_27
{
    public static class Four
    {
        public static List<int> Solve(long[] a)
        {
            int n = a.Length;

            if (n < 4)
            {
                throw new ArgumentException("a length should be longer or equal than 4");
            }

            SortedDictionary<long, Tuple<int, int>> sums = new SortedDictionary<long, Tuple<int, int>>();
            long bufferSum;

            for (int current = 1; current < n; current++)
            {
                for (int next = current + 1; next < n; next++)
                {
                    bufferSum = a[current] + a[next];

                    if (sums.ContainsKey(-bufferSum))
                    {
                        Tuple<int, int> value = sums[-bufferSum];

                        return new List<int> { value.Item1, value.Item2, current, next };
                    }
                }

                for (int prev = 0; prev < current; prev++)
                {
                    bufferSum = a[prev] + a[current];
                    sums[bufferSum] = new Tuple<int, int>(prev, current);
                }
            }

            return null;
        }
    }

    [TestClass]
    public class FourTest
    {
        [TestMethod]
        public void Test1()
        {
            long[] a = new long[] { -7, 1, 3, 7, 10, -14, 20 };
            List<int> result = Four.Solve(a);

            Assert.IsNotNull(result);
            this.Check(a, result);
        }

        [TestMethod]
        public void Test2()
        {
            long[] a = new long[] { 1, 2, 3, 4 };
            List<int> result = Four.Solve(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test3()
        {
            long[] a = new long[] { -1, -2, -3, -4, 5 };
            List<int> result = Four.Solve(a);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test4()
        {
            long[] a = new long[] { -1, -2, -3, -4, 5, 6 };
            List<int> result = Four.Solve(a);

            Assert.IsNotNull(result);
            this.Check(a, result);
        }

        [TestMethod]
        public void Test5()
        {
            long[] a = new long[] { -1, -2, 1, 2 };
            List<int> result = Four.Solve(a);

            Assert.IsNotNull(result);
            this.Check(a, result);
        }

        [TestMethod]
        public void Test6()
        {
            long[] a = new long[] { 0, 0, 0, 0, 0 };
            List<int> result = Four.Solve(a);

            Assert.IsNotNull(result);
            this.Check(a, result);
        }


        private void Check(long[] a, List<int> result)
        {
            int n = a.Length;

            SortedSet<int> set = new SortedSet<int>();
            long sum = 0;

            Assert.AreEqual(4, result.Count);

            foreach (int index in result)
            {
                Assert.IsTrue(index >= 0);
                Assert.IsTrue(index < n);
                Assert.IsTrue(!set.Contains(index));
                set.Add(index);

                sum += a[index];
            }

            Assert.AreEqual(0, sum);
        }
    }
}
