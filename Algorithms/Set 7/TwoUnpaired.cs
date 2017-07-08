using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_7
{
    public static class TwoUnpaired
    {
        public static Tuple<int, int> Solve(int[] numbers)
        {
            int xor = 0;
            foreach (int number in numbers)
            {
                xor ^= number;
            }

            int digit = 0;
            while ((xor & (1 << digit)) == 0)
            {
                digit++;
            }

            int zero = 0;
            int one = 0;

            foreach (int number in numbers)
            {
                if ((number & (1 << digit)) == 0)
                {
                    zero ^= number;
                }
                else
                {
                    one ^= number;
                }
            }

            return new Tuple<int, int>(Math.Min(zero, one), Math.Max(zero, one));
        }
    }

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void Test1()
        {
            int[] numbers = new int[] { 2, 3, 4, 2, 3, 5 };

            Tuple<int, int> result = TwoUnpaired.Solve(numbers);
            Assert.AreEqual(4, result.Item1);
            Assert.AreEqual(5, result.Item2);
        }

        [TestMethod]
        public void Test2()
        {
            int[] numbers = new int[] { 1, 1, 1, 1, 11, 9, 10, 7, 9, 10 };

            Tuple<int, int> result = TwoUnpaired.Solve(numbers);
            Assert.AreEqual(7, result.Item1);
            Assert.AreEqual(11, result.Item2);
        }
    }
}
