using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public class Interval
    {
        public static int[] Solve(Tuple<int, int>[] inputRanges, int start, int finish)
        {
            if (inputRanges.Length == 0)
            {
                throw new ArgumentException("Input should contain at least 1 range");
            }

            int n = inputRanges.Length;
            Range[] ranges = new Range[n];

            for (int i = 0; i < n; i++)
            {
                ranges[i] = new Range() { Start = inputRanges[i].Item1, Finish = inputRanges[i].Item2, Number = i };
            }

            Array.Sort(ranges);

            int left = 0;
            int right = 0;
            List<int> result = new List<int>();

            if (ranges[left].Start > start)
            {
                throw new ArgumentException("Start is not covered");
            }

            while (left < n && ranges[left].Start <= start)
            {
                if (ranges[left].Finish > ranges[right].Finish)
                {
                    right = left;
                }
                left++;
            }

            result.Add(ranges[right].Number);
            int nextRight = -1;
            while (left < n && ranges[left].Start <= finish)
            {
                if (ranges[left].Start > ranges[right].Finish)
                {
                    if (nextRight == -1)
                    {
                        throw new ArgumentException("Unable to cover");
                    }

                    if (ranges[nextRight].Finish < ranges[left].Start)
                    {
                        throw new ArgumentException("Found gap in ranges");
                    }

                    right = nextRight;
                    result.Add(ranges[right].Number);
                    nextRight = -1;
                }

                if (nextRight == -1 || ranges[left].Finish > ranges[nextRight].Finish)
                {
                    nextRight = left;
                }

                left++;
            }

            if (ranges[right].Finish < finish && nextRight != -1)
            {
                right = nextRight;
                result.Add(ranges[right].Number);
            }

            if (ranges[right].Finish < finish)
            {
                throw new ArgumentException("Finish is not covered");
            }

            return result.ToArray();
        }

        private class Range : IComparable<Range>
        {
            public int Start { get; set; }
            public int Finish { get; set; }
            public int Number { get; set; }

            public int CompareTo(Range other)
            {
                if (this.Start != other.Start)
                {
                    return this.Start.CompareTo(other.Start);
                }

                if (this.Finish != other.Finish)
                {
                    return this.Finish.CompareTo(other.Finish);
                }

                return this.Number.CompareTo(other.Number);
            }
        }
    }

    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void Test1()
        {
            Tuple<int, int>[] inputRanges = new Tuple<int, int>[]
            {
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(30, 40),
                new Tuple<int, int>(20, 91),
                new Tuple<int, int>(8, 10),
                new Tuple<int, int>(6, 7),
                new Tuple<int, int>(3, 9),
                new Tuple<int, int>(9, 12),
                new Tuple<int, int>(11, 14),
            };
            int start = 3;
            int finish = 13;

            int[] result = Interval.Solve(inputRanges, start, finish);
            Assert.AreEqual(3, result.Length);
            Assert.IsTrue(this.Check(inputRanges, start, finish, result));
        }

        private bool Check(Tuple<int, int>[] inputRanges, int start, int finish, int[] result)
        {
            if (result.Length == 0)
            {
                return false;
            }

            if (inputRanges[result[0]].Item1 > start || inputRanges[result[0]].Item2 <= start)
            {
                return false;
            }

            int m = result.Length;

            if (inputRanges[result[m - 1]].Item1 > finish || inputRanges[result[m - 1]].Item2 <= finish)
            {
                return false;
            }

            for (int i = 1; i < m; i++)
            {
                if (inputRanges[result[i - 1]].Item2 < inputRanges[result[i]].Item1 - 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
