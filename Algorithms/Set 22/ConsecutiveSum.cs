using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Set_22
{
    public static class ConsecutiveSum
    {
        public static bool Solve(int[] input, int targetSum, out int start, out int length)
        {
            int left = 0;
            int sum = 0;

            for (int right = 0;right < input.Length;right++)
            {
                sum += input[right];

                while (sum > targetSum)
                {
                    sum -= input[left];
                    left++;
                }

                if (sum == targetSum)
                {
                    start = left;
                    length = right - left + 1;
                    return true;
                }
            }

            start = -1;
            length = -1;
            return false;
        }
    }

    [TestClass]
    public class ConsecutiveSumTest
    {
        private int[] input = new int[] { 1, 3, 5, 7, 9 };

        [TestMethod]
        public void Test1()
        {
            int start, length;
            int targetSum = 8;

            Assert.IsTrue(ConsecutiveSum.Solve(this.input, targetSum, out start, out length));
            Assert.IsTrue(this.Check(this.input, targetSum, start, length));
        }

        [TestMethod]
        public void Test2()
        {
            int start, length;
            int targetSum = 15;

            Assert.IsTrue(ConsecutiveSum.Solve(this.input, targetSum, out start, out length));
            Assert.IsTrue(this.Check(this.input, targetSum, start, length));
        }

        [TestMethod]
        public void Test3()
        {
            int start, length;
            int targetSum = 6;

            Assert.IsFalse(ConsecutiveSum.Solve(this.input, targetSum, out start, out length));
        }

        private bool Check(int[] input, int targetSum, int start, int length)
        {
            if (start < 0 || start >= input.Length)
            {
                return false;
            }

            int sum = 0;
            for (int i=0;i<length;i++)
            {
                if (start + i >= input.Length)
                {
                    return false;
                }

                sum += input[start + i];
            }

            return sum == targetSum;
        }
    }
}
