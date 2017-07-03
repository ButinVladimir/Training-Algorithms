using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_6
{
    public static class DisjointSubarrays
    {
        public static int Solve(int[] array)
        {
            ComparerGreater comparerGreater = new ComparerGreater();
            ComparerLesser comparerLesser = new ComparerLesser();
            IteratorBackward iteratorBackward = new IteratorBackward() { Array = array };
            IteratorForward iteratorForward = new IteratorForward() { Array = array };

            PartialCalc prefixGreater = new PartialCalc() {
                Array = array,
                BetterComparer = comparerGreater,
                WorseComparer = comparerLesser,
                Iterator = iteratorForward
            };
            PartialCalc prefixLesser = new PartialCalc()
            {
                Array = array,
                BetterComparer = comparerLesser,
                WorseComparer = comparerGreater,
                Iterator = iteratorForward
            };
            PartialCalc suffixGreater = new PartialCalc()
            {
                Array = array,
                BetterComparer = comparerGreater,
                WorseComparer = comparerLesser,
                Iterator = iteratorBackward
            };
            PartialCalc suffixLesser = new PartialCalc()
            {
                Array = array,
                BetterComparer = comparerLesser,
                WorseComparer = comparerGreater,
                Iterator = iteratorBackward
            };

            prefixGreater.Calculate();
            prefixLesser.Calculate();
            suffixGreater.Calculate();
            suffixLesser.Calculate();

            int result = Math.Abs(prefixGreater.PartialValues[0].Sum - suffixLesser.PartialValues[1].Sum);

            for (int i = 0; i < array.Length - 1; i++)
            {
                result = Math.Max(result, Math.Abs(prefixGreater.PartialValues[i].Sum - suffixLesser.PartialValues[i + 1].Sum));
                result = Math.Max(result, Math.Abs(prefixLesser.PartialValues[i].Sum - suffixGreater.PartialValues[i + 1].Sum));
            }

            return result;
        }

        private class PartialCalc
        {
            public int[] Array { get; set; }
            public Value[] PartialValues { get; private set; }
            public BaseIterator Iterator { get; set; }
            public BaseComparer BetterComparer { get; set; }
            public BaseComparer WorseComparer { get; set; }

            public void Calculate()
            {
                this.PartialValues = new Value[this.Array.Length];

                this.Iterator.Start();
                int prevSum = this.Array[this.Iterator.Position];
                int extValue = this.Array[this.Iterator.Position];
                int extPosition = this.Iterator.Position;
                this.PartialValues[this.Iterator.Position] = new Value
                {
                    End = this.Iterator.Position,
                    Start = this.Iterator.Position,
                    Sum = prevSum
                };

                int nextSum;

                this.Iterator.Next();

                while (!this.Iterator.IsEnded())
                {
                    nextSum = prevSum + this.Array[this.Iterator.Position];
                    this.PartialValues[this.Iterator.Position] = new Value
                    {
                        End = this.Iterator.Position,
                        Start = this.Iterator.GetStartPosition(),
                        Sum = nextSum
                    };

                    nextSum = prevSum + this.Array[this.Iterator.Position] - extValue;
                    if (this.BetterComparer.IsBetter(nextSum, this.PartialValues[this.Iterator.Position].Sum))
                    {
                        this.PartialValues[this.Iterator.Position] = new Value
                        {
                            End = this.Iterator.Position,
                            Start = this.Iterator.GetNext(extPosition),
                            Sum = nextSum
                        };
                    }

                    prevSum = prevSum + this.Array[this.Iterator.Position];
                    if (this.WorseComparer.IsBetter(prevSum, extValue))
                    {
                        extValue = prevSum;
                        extPosition = this.Iterator.Position;
                    }

                    this.Iterator.Next();
                }
            }
        }

        private class Value
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Sum { get; set; }
        }

        #region Iterators 

        private abstract class BaseIterator
        {
            public int[] Array { get; set; }
            public int Position { get; protected set; }

            public void Start()
            {
                this.Position = this.GetStartPosition();
            }

            public void Next()
            {
                this.Position = this.GetNext(this.Position);
            }

            public abstract bool IsEnded();
            public abstract int GetStartPosition();
            public abstract int GetNext(int position);
        }

        private class IteratorForward : BaseIterator
        {
            public override bool IsEnded()
            {
                return this.Position >= this.Array.Length;
            }

            public override int GetNext(int position)
            {
                return position + 1;
            }

            public override int GetStartPosition()
            {
                return 0;
            }
        }

        private class IteratorBackward : BaseIterator
        {
            public override bool IsEnded()
            {
                return this.Position < 0;
            }

            public override int GetNext(int position)
            {
                return position - 1;
            }

            public override int GetStartPosition()
            {
                return this.Array.Length - 1;
            }
        }

        #endregion

        #region Comparators

        private interface BaseComparer
        {
            bool IsBetter(int newValue, int oldValue);
        }

        private class ComparerGreater : BaseComparer
        {
            bool BaseComparer.IsBetter(int newValue, int oldValue)
            {
                return newValue > oldValue;
            }
        }

        private class ComparerLesser : BaseComparer
        {
            bool BaseComparer.IsBetter(int newValue, int oldValue)
            {
                return newValue < oldValue;
            }
        }

        #endregion
    }

    [TestClass]
    public class DisjointSubarraysTest
    {
        [TestMethod]
        public void Test()
        {
            int[] array = new int[] { 2, -1, -2, 1, -4, 2, 8 };

            Assert.AreEqual(16, DisjointSubarrays.Solve(array));
        }
    }
}
