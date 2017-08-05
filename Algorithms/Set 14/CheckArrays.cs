using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_14
{
    public static class CheckArrays
    {
        public static bool SolveWithSort(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            Array.Sort(a);
            Array.Sort(b);

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool SolveWithoutSort(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            Dictionary<int, int> values = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!values.ContainsKey(a[i]))
                {
                    values[a[i]] = 0;
                }

                values[a[i]]++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!values.ContainsKey(b[i]))
                {
                    return false;
                }

                values[b[i]]--;
            }

            foreach (var kv in values)
            {
                if (kv.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    [TestClass]
    public class CheckArraysTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] a = new int[] { 1, 2, 3, 1, 4, 5, 6, 7 };
            int[] b = new int[] { 2, 1, 6, 4, 5, 7, 3, 1 };

            bool notSorted = CheckArrays.SolveWithoutSort(a, b);
            bool sorted = CheckArrays.SolveWithSort(a, b);

            Assert.AreEqual(notSorted, sorted);
        }

        [TestMethod]
        public void Test2()
        {
            int[] a = new int[] { 3, 5, 1, 3, 7, 2, 11 };
            int[] b = new int[] { 1, 3, 5, 2, 3, 7, 10 };

            bool notSorted = CheckArrays.SolveWithoutSort(a, b);
            bool sorted = CheckArrays.SolveWithSort(a, b);

            Assert.AreEqual(notSorted, sorted);
        }
    }
}
