using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_61
{
    public class CPCRC1
    {
        private const long TEN = 10;
        private const long DIGITS_SUM = 0 + 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;

        public static long Solve(long number)
        {
            if (number == 0)
            {
                return 0;
            }

            long multiplier = 1;
            long rightPart = 0;
            long result = 0;
            long digit;

            while (number > 0)
            {
                digit = number % TEN;
                number /= TEN;

                if (number > 0)
                {
                    result += DIGITS_SUM * number * multiplier;
                }

                for (long i = 0; i < digit; i++)
                {
                    result += i * multiplier;
                }

                result += digit * (rightPart + 1);

                rightPart += multiplier * digit;
                multiplier *= TEN;
            }

            return result;
        }
    }
}
