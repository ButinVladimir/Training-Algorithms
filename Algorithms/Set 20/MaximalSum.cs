using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_20
{
    public static class MaximalSum
    {
        public static int Solve(int[] values)
        {
            if (values.Length == 0)
            {
                return 0;
            }

            int currentSum = values[0];
            int minSum = values[0];
            int maxSum = values[0];
            int nextSum;

            for (int i = 1; i < values.Length; i++)
            {
                currentSum += values[i];
                nextSum = currentSum - minSum;

                maxSum = Math.Max(nextSum, maxSum);
                maxSum = Math.Max(currentSum, maxSum);
                minSum = Math.Min(currentSum, minSum);
            }

            return maxSum;
        }

        public static int SolveBrute(int[] values)
        {
            int maxSum = values[0];
            int currentSum;

            for (int i = 0; i < values.Length; i++)
            {
                currentSum = 0;

                for (int j = i; j < values.Length; j++)
                {
                    currentSum += values[j];
                    maxSum = Math.Max(currentSum, maxSum);
                }
            }

            return maxSum;
        }
    }

    [TestClass]
    public class MaximalSumTest
    {
        [TestMethod]
        public void Test1()
        {
            int[] values = { 1, 2, 3, 4, 5 };

            Test(values);
            Assert.AreEqual(15, MaximalSum.Solve(values));
        }

        [TestMethod]
        public void Test2()
        {
            int[] values = { -1, -2, -3, -4, -5 };

            Test(values);
            Assert.AreEqual(-1, MaximalSum.Solve(values));
        }

        [TestMethod]
        public void Test3()
        {
            int[] values = { -1, 2, -3, -4, 5 };

            Test(values);
            Assert.AreEqual(5, MaximalSum.Solve(values));
        }

        [TestMethod]
        public void Test4()
        {
            int[] values = { 5, -4, 3, -5, 10 };

            Test(values);
        }

        private void Test(int[] values)
        {
            Assert.AreEqual(MaximalSum.SolveBrute(values), MaximalSum.Solve(values));
        }
    }
}
