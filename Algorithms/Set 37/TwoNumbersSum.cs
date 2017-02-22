using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_37
{
    class TwoNumbersSum
    {
        public static Tuple<int, int> Solve(int[] numbers, int m)
        {
            int[] sortedNumbers = new int[numbers.Length];
            numbers.CopyTo(sortedNumbers, 0);

            Array.Sort(sortedNumbers);

            int p1 = 0;
            int p2 = sortedNumbers.Length - 1;
            int sum;

            while (p1 < p2)
            {
                sum = sortedNumbers[p1] + sortedNumbers[p2];
                if (sum == m)
                {
                    return new Tuple<int, int>(sortedNumbers[p1], sortedNumbers[p2]);
                }

                if (sum > m)
                {
                    p2--;
                }
                else
                {
                    p1++;
                }
            }

            return null;
        }
    }
}
