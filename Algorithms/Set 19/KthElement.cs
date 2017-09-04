using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_19
{
    public abstract class KthElement
    {
        public Tuple<int, int>[] Ranges { get; set; }

        public abstract int Solve(int n);
    }

    public class KthElementNLogN : KthElement
    {
        public override int Solve(int n)
        {
            int step, current, next, left, right;

            foreach (var range in this.Ranges)
            {
                current = range.Item1 - 1;
                step = range.Item2 - range.Item1 + 1;

                while (step > 0)
                {
                    next = current + step;
                    left = this.Less(next) + 1;
                    right = this.LessOrEqual(next);

                    if (n < left)
                    {
                        step /= 2;
                    }
                    else
                    if (n > right)
                    {
                        current = next;
                    }
                    else
                    {
                        return next;
                    }
                }
            }

            throw new ArgumentException("Invalid number");
        }

        private int Less(int value)
        {
            int result = 0;
            foreach (var range in this.Ranges)
            {
                if (range.Item2 < value)
                {
                    result += range.Item2 - range.Item1 + 1;
                }
                else if (range.Item1 < value)
                {
                    result += value - range.Item1;
                }
            }

            return result;
        }

        private int LessOrEqual(int value)
        {
            int result = 0;
            foreach (var range in this.Ranges)
            {
                if (range.Item2 <= value)
                {
                    result += range.Item2 - range.Item1 + 1;
                }
                else if (range.Item1 <= value)
                {
                    result += value - range.Item1 + 1;
                }
            }

            return result;
        }
    }

    public class KthElementN : KthElement
    {
        public override int Solve(int n)
        {
            List<State> stateList = new List<State>();
            foreach (var range in this.Ranges)
            {
                stateList.Add(new State()
                {
                    Close = false,
                    Value = range.Item1
                });

                stateList.Add(new State()
                {
                    Close = true,
                    Value = range.Item2
                });
            }

            State[] states = stateList.ToArray();
            Array.Sort(states);

            int left, right;
            int previous = states[0].Value;
            int open = 0;
            int close = 0;
            int opened = 0;
            left = 0;
            right = 0;
            int valueLeft, valueRight;

            while (left < states.Length)
            {
                valueLeft = previous + 1;
                valueRight = states[left].Value - 1;

                if (valueLeft <= valueRight)
                {
                    if ((valueRight - valueLeft + 1) * opened >= n)
                    {
                        return valueLeft + ((n - 1) / opened);
                    }

                    n -= (valueRight - valueLeft + 1) * opened;
                }

                previous = states[left].Value;

                right = left;
                open = 0;
                close = 0;
                while (right < states.Length && states[left].Value == states[right].Value)
                {
                    if (states[right].Close)
                    {
                        close++;
                    }
                    else
                    {
                        open++;
                    }

                    right++;
                }

                opened += open;

                if (n <= opened)
                {
                    return states[left].Value;
                }

                n -= opened;
                opened -= close;

                left = right;
            }

            throw new ArgumentException("Invalid number");
        }

        private class State:IComparable<State>
        {
            public int Value { get; set; }
            public bool Close { get; set; }

            public int CompareTo(State other)
            {
                if (this.Value != other.Value)
                {
                    return this.Value.CompareTo(other.Value);
                }

                return this.Close.CompareTo(other.Close);
            }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class KthElementTest
    {
        [TestMethod]
        public void Test1()
        {
            Tuple<int, int>[] ranges = new Tuple<int, int>[]
            {
                new Tuple<int, int>(2,8),
                new Tuple<int, int>(5,10),
                new Tuple<int, int>(7,20)
            };

            KthElementNLogN nlogn = new KthElementNLogN() { Ranges = ranges };
            KthElementN n = new KthElementN() { Ranges = ranges };

            this.Compare(2, 1, nlogn, n);
            this.Compare(5, 4, nlogn, n);
            this.Compare(5, 5, nlogn, n);
            this.Compare(7, 10, nlogn, n);
        }

        private void Compare(int expected, int value, KthElementNLogN nlogn, KthElementN n)
        {
            Assert.AreEqual(expected, nlogn.Solve(value));
            Assert.AreEqual(expected, n.Solve(value));
        }
    }
}
