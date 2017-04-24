using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public class ImportantValue
    {
        private int n;
        private List<Rib>[] to;
        private Dictionary<Tuple<int, int>, Rib> ribMapping;
        private int[] count;
        private int result;

        public ImportantValue(int n, IEnumerable<Tuple<int, int, int>> ribs)
        {
            this.n = n;
            this.to = new List<Rib>[this.n];
            this.ribMapping = new Dictionary<Tuple<int, int>, Rib>();
            this.count = new int[this.n];

            for (int i = 0; i < n; i++)
            {
                this.to[i] = new List<Rib>();
            }

            int ribCount = 0;
            foreach (var rib in ribs)
            {
                int from = Math.Min(rib.Item1, rib.Item2) - 1;
                int to = Math.Max(rib.Item1, rib.Item2) - 1;

                Rib ribObject = new Rib()
                {
                    From = from,
                    To = to,
                    Value = rib.Item3
                };

                this.ribMapping[new Tuple<int, int>(from, to)] = ribObject;
                this.to[from].Add(ribObject);
                this.to[to].Add(ribObject);

                ribCount++;
            }

            this.result = 0;
            this.DFSInit(0);
        }

        public int Query()
        {
            return this.result;
        }

        public int QueryBrute()
        {
            int result = 0;

            for (int i = 0; i < this.n; i++)
            {
                this.DFSBrute(i, ref result);
            }

            return result / 2;
        }

        public void ChangeRib(int from, int to, int value)
        {
            int buffer;
            if (from > to)
            {
                buffer = from;
                from = to;
                to = buffer;
            }
            from--;
            to--;

            Rib rib = this.ribMapping[new Tuple<int, int>(from, to)];

            int subCount = Math.Min(this.count[from], this.count[to]);
            result += (value - rib.Value) * subCount * (this.n - subCount);

            rib.Value = value;
        }

        private void DFSInit(int current, int prev = -1)
        {
            this.count[current] = 1;

            foreach (Rib rib in this.to[current])
            {
                int next = rib.From == current ? rib.To : rib.From;

                if (prev == next)
                {
                    continue;
                }

                this.DFSInit(next, current);
                this.count[current] += this.count[next];

                result += (this.n - this.count[next]) * this.count[next] * rib.Value;
            }
        }

        private void DFSBrute(int current, ref int result, int prev = -1, int accumulatedSum = 0)
        {
            result += accumulatedSum;

            foreach (Rib rib in this.to[current])
            {
                int next = rib.From == current ? rib.To : rib.From;

                if (prev == next)
                {
                    continue;
                }

                this.DFSBrute(next, ref result, current, accumulatedSum + rib.Value);
            }
        }

        private class Rib
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Value { get; set; }
        }
    }

    [TestClass]
    public class ImportantValueTest
    {
        [TestMethod]
        public void Test1()
        {
            ImportantValue iv = new ImportantValue(3, new List<Tuple<int, int, int>>
            {
                new Tuple<int, int, int>(1, 2, 2),
                new Tuple<int, int, int>(2, 3, 3),
            });

            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(1, 2, 4);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(2, 3, 2);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
        }

        [TestMethod]
        public void Test2()
        {
            ImportantValue iv = new ImportantValue(7, new List<Tuple<int, int, int>>
            {
                new Tuple<int, int, int>(1, 2, 2),
                new Tuple<int, int, int>(1, 3, 5),
                new Tuple<int, int, int>(1, 4, 8),
                new Tuple<int, int, int>(2, 5, 3),
                new Tuple<int, int, int>(2, 6, 7),
                new Tuple<int, int, int>(2, 7, 11),
            });

            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(1, 2, 4);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(1, 3, 2);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(2, 7, 1);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(5, 2, 11);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(1, 4, -1);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
            iv.ChangeRib(6, 2, -10);
            Assert.AreEqual(iv.QueryBrute(), iv.Query());
        }
    }
}
