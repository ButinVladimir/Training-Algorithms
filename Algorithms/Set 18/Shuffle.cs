using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_18
{
    public static class Shuffle
    {
        public static void Solve(int[] a)
        {
            int n = a.Length / 2;

            int posB = n;

            int posCurrent;
            for (int i = 0; i < n; i++)
            {
                posCurrent = posB;

                while (posCurrent > 2 * i + 1)
                {
                    Swap(a, posCurrent, posCurrent - 1);
                    posCurrent--;
                }

                posB++;
            }
        }

        private static void Swap(int[] a, int p1, int p2)
        {
            int buf = a[p1];
            a[p1] = a[p2];
            a[p2] = buf;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ShuffleTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            Shuffle.Solve(a);

            int[] expected = new int[] { 1, 5, 2, 6, 3, 7, 4, 8 };
            CollectionAssert.AreEqual(expected, a);
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Shuffle.Solve(a);

            int[] expected = new int[] { 1, 6, 2, 7, 3, 8, 4, 9, 5, 10 };
            CollectionAssert.AreEqual(expected, a);
        }
    }
}
