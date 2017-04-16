using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_24
{
    public class NumberOf2
    {
        public static long Solve(long n)
        {
            if (n == 0)
            {
                return 0;
            }

            long[] digits = ToArray(n);
            int l = digits.Length;
            long[] countPerDigits = new long[l];

            countPerDigits[0] = 1;
            int mult = 10;
            for (int i = 1; i < l; i++)
            {
                countPerDigits[i] = countPerDigits[i - 1] * 10 + mult;
                mult *= 10;
            }

            long result = 0;
            long buffer = 0;
            mult = 1;

            for (int i = 1; i < l; i++)
            {
                mult *= 10;
            }

            for (int i = l - 1; i >= 1; i--)
            {
                result += digits[i] * countPerDigits[i - 1];
                result += digits[i] * mult * buffer;

                if (digits[i] > 2)
                {
                    result += mult;
                }

                if (digits[i] == 2)
                {
                    buffer++;
                }

                mult /= 10;
            }

            result += (digits[0] + 1) * buffer;
            if (digits[0] >= 2)
            {
                result++;
            }

            return result;
        }

        public static long SolveBrute(long n)
        {
            long result = 0;

            for (int i = 0; i <= n; i++)
            {
                long buffer = i;

                while (buffer > 0)
                {
                    if (buffer % 10 == 2)
                    {
                        result++;
                    }

                    buffer /= 10;
                }
            }

            return result;
        }

        private static long[] ToArray(long n)
        {
            List<long> digits = new List<long>();

            while (n > 0)
            {
                digits.Add(n % 10);
                n /= 10;
            }

            return digits.ToArray();
        }
    }

    [TestClass]
    public class NumberOf2Test
    {
        [TestMethod]
        public void Test1()
        {
            long n = 5555;

            Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
        }

        [TestMethod]
        public void Test2()
        {
            long n = 123123;

            Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
        }

        [TestMethod]
        public void Test3()
        {
            long n = 4;

            Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
        }

        [TestMethod]
        public void Test4()
        {
            long n = 22222;

            Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
        }

        [TestMethod]
        public void Test5()
        {
            long n = 19;

            Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
        }

        [TestMethod]
        public void Test6()
        {
            Random random = new Random(1);
            for (int i = 0; i < 100; i++)
            {
                long n = random.Next(1000000);

                Assert.AreEqual(NumberOf2.SolveBrute(n), NumberOf2.Solve(n));
            }
        }
    }
}
