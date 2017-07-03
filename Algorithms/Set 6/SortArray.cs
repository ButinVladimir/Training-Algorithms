using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_6
{
    public static class SortArray
    {
        public static void Solve(int[] a)
        {
            int[] buffer = new int[a.Length];
            int position = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < 0)
                {
                    buffer[position++] = a[i];
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 0)
                {
                    buffer[position++] = a[i];
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = buffer[i];
            }
        }
    }

    [TestClass]
    public class SortArrayTest
    {
        [TestMethod]
        public void Test()
        {
            int[] a = new int[] { -1, 1, 3, -2, 2 };
            int[] answer = new int[] { -1, -2, 1, 3, 2 };

            SortArray.Solve(a);

            Assert.AreEqual(answer.Length, a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Assert.AreEqual(answer[i], a[i]);
            }
        }
    }
}