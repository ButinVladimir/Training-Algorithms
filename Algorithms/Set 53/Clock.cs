using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_53
{
    class Clock
    {
        private const int Format12 = 12;

        private const int Format24 = 24;

        private static readonly char[] Separator = new char[] {':'};

        public static string Solve(int format, string value)
        {
            int[] numbers = Array.ConvertAll(value.Split(Separator), int.Parse);

            if (format == Format12)
            {
                if (numbers[0] == 0)
                {
                    numbers[0] = 1;
                }
                else if (numbers[0] > 12)
                {
                    numbers[0] = numbers[0] % 10;

                    if (numbers[0] == 0)
                    {
                        numbers[0] = 10;
                    }
                }
            }
            else if (format == Format24)
            {
                if (numbers[0] >= 24)
                {
                    numbers[0] = 10 + (numbers[0] % 10);
                }
            }

            if (numbers[1] > 59)
            {
                numbers[1] = 10 + (numbers[1] % 10);
            }

            return ConvertToString(numbers);
        }

        private static string ConvertToString(int[] numbers)
        {
            StringBuilder sb = new StringBuilder();

            if (numbers[0] < 10)
            {
                sb.Append('0');
            }

            sb.Append(numbers[0]);

            sb.Append(':');

            if (numbers[1] < 10)
            {
                sb.Append('0');
            }

            sb.Append(numbers[1]);

            return sb.ToString();
        }
    }
}
