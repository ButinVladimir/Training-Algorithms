using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_6
{
    public class Pots
    {
        public int[] Values { get; set; }

        private SortedDictionary<Tuple<int, int>, Tuple<int, int>> intermediateValues;

        public int Solve()
        {
            this.intermediateValues = new SortedDictionary<Tuple<int, int>, Tuple<int, int>>();

            return this.Solve(0, this.Values.Length - 1).Item1;
        }

        private Tuple<int, int> Solve(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            if (left == right)
            {
                return new Tuple<int, int>(this.Values[left], 0);
            }

            Tuple<int, int> key = new Tuple<int, int>(left, right);
            if (this.intermediateValues.ContainsKey(key))
            {
                return this.intermediateValues[key];
            }

            Tuple<int, int> buffer = this.Solve(left + 1, right);
            Tuple<int, int> result = new Tuple<int, int>(this.Values[left] + buffer.Item2, buffer.Item1);

            buffer = this.Solve(left, right - 1);
            if (this.Values[right] + buffer.Item2 > result.Item1)
            {
                result = new Tuple<int, int>(this.Values[right] + buffer.Item2, buffer.Item1);
            }

            this.intermediateValues[key] = result;

            return result;
        }
    }

    [TestClass]
    public class PotsTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] values = new int[] { 1, 1, 1, 1, 1 };
            Pots pots = new Pots() { Values = values };

            Assert.AreEqual(3, pots.Solve());
        }

        [TestMethod]
        public void Test2()
        {
            int[] values = new int[] { 1, 2, 3, 4, 5 };
            Pots pots = new Pots() { Values = values };

            Assert.AreEqual(9, pots.Solve());
        }

        [TestMethod]
        public void Test3()
        {
            int[] values = new int[] { 1, 3, 4, 5, 1 };
            Pots pots = new Pots() { Values = values };

            Assert.AreEqual(6, pots.Solve());
        }
    }
}
