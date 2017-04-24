using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_20
{
    public static class MoveZeros
    {
        public static int[] Solve(int[] values)
        {
            int[] result = new int[values.Length];

            int left = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != 0)
                {
                    result[left] = values[i];
                    left++;
                }
            }

            while (left < values.Length)
            {
                result[left] = 0;
                left++;
            }

            return result;
        }

        public static int[] SolveBrute(int[] values)
        {
            List<int> sortedValues = new List<int>();
            int zeroCount = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    sortedValues.Add(values[i]);
                }
            }

            for (int i = 0; i < zeroCount; i++)
            {
                sortedValues.Add(0);
            }

            return sortedValues.ToArray();
        }
    }

    [TestClass]
    public class MoveZerosTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            this.Compare(MoveZeros.Solve(a), MoveZeros.SolveBrute(a));
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = { 0, 2, 0, 4, 0 };

            this.Compare(MoveZeros.Solve(a), MoveZeros.SolveBrute(a));
        }

        [TestMethod]
        public void Test3()
        {
            int[] a = { 1, 2, 0, 4, 0 };

            this.Compare(MoveZeros.Solve(a), MoveZeros.SolveBrute(a));
        }

        [TestMethod]
        public void Test4()
        {
            int[] a = { 5, 6, 0, 0, 0 };

            this.Compare(MoveZeros.Solve(a), MoveZeros.SolveBrute(a));
        }

        private void Compare(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
