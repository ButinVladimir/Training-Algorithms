using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_53
{
    class LastDigitFactorial
    {
        public static int SolveWithZero(int n)
        {
            if (n >= 5)
            {
                return 0;
            }

            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result % 10;
        }

        public static int SolveWithoutZero(int n)
        {
            int count2 = 0;
            int count5 = 0;
            int number;
            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                number = i;
                count2 += GetPower(2, ref number);
                count5 += GetPower(5, ref number);

                result = (result * number) % 10;
            }

            int zeros = Math.Min(count2, count5);
            count2 -= zeros;
            count5 -= zeros;

            result = ApplyPower(result, 2, count2);
            result = ApplyPower(result, 5, count5);

            return result;
        }

        private static int GetPower(int b, ref int number)
        {
            int result = 0;

            while (number % b == 0)
            {
                result++;
                number /= b;
            }

            return result;
        }

        private static int ApplyPower(int number, int b, int power)
        {
            for (int i = 0; i < power; i++)
            {
                number = (number * b) % 10;
            }

            return number;
        }
    }
}
