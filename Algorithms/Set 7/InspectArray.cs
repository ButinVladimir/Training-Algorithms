using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_7
{
    public static class InspectArray
    {
        public static void Solve(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                if (array[i] <= 0)
                {
                    continue;
                }

                while (array[i] > 0)
                {
                    if (array[i] == i + 1)
                    {
                        array[i] = -1;

                        break;
                    }

                    int p = array[i] - 1;
                    if (array[p] > 0)
                    {
                        array[i] = array[p];
                        array[p] = -1;
                    }
                    else
                    {
                        array[p]--;
                        array[i] = 0;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = -array[i];
            }
        }
    }

    [TestClass]
    public class InspectArrayTest
    {
        [TestMethod]
        public void Test()
        {
            int[] array = { 1, 1, 3, 2 };
            int[] result = { 2, 1, 1, 0 };

            InspectArray.Solve(array);
            Compare(result, array);
        }

        [TestMethod]
        public void Test2()
        {
            int[] array = { 5, 5, 5, 5, 5 };
            int[] result = { 0, 0, 0, 0, 5 };

            InspectArray.Solve(array);
            Compare(result, array);
        }

        [TestMethod]
        public void Test3()
        {
            int[] array = { 2, 3, 4, 4, 3 };
            int[] result = { 0, 1, 2, 2, 0 };

            InspectArray.Solve(array);
            Compare(result, array);
        }


        private static void Compare(int[] expected, int[] result)
        {
            Assert.AreEqual(expected.Length, result.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
