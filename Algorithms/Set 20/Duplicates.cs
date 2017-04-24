using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_20
{
    public static class Duplicates
    {
        public static int Solve(int[] values)
        {
            Array.Sort(values);

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] == values[i - 1])
                {
                    return values[i - 1];
                }
            }

            return 0;
        }
    }

    [TestClass]
    public class DuplicatesTest
    {
        [TestMethod]
        public void Test()
        {
            int[] values = { 1, 3, 4, 2, 5, 3 };

            Assert.AreEqual(3, Duplicates.Solve(values));
        }
    }
}
