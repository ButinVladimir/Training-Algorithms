using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_30
{
    public class Inversions
    {
        public static long Solve(int[] numbers)
        {
            int n = numbers.Length;

            int[] indexes = new int[n];
            int[] buffer = new int[n];
            long[] inversionsOld = new long[n];
            long[] inversionsNew = new long[n];

            for (int i = 0; i < n; i++)
            {
                inversionsNew[i] = 1;
            }

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    inversionsOld[i] = inversionsNew[i];
                    inversionsNew[i] = 0;
                    indexes[i] = i;
                }

                InversionsRecursive(0, n-1, numbers, indexes, inversionsNew, buffer, inversionsOld);
            }

            return inversionsNew.Sum();
        }

        private static void InversionsRecursive(int l, int r, int[] numbers, int[] indexes, long[] inversionsNew, int[] buffer, long[] inversionsOld)
        {
            if (l >= r)
            {
                return;
            }

            int m = (l + r) / 2;
            InversionsRecursive(l, m, numbers, indexes, inversionsNew, buffer, inversionsOld);
            InversionsRecursive(m + 1, r, numbers, indexes, inversionsNew, buffer, inversionsOld);

            int p = 0;
            int p1 = l;
            int p2 = m + 1;
            long sum = 0;

            while (p1 <= m && p2 <= r)
            {
                if (numbers[indexes[p2]] < numbers[indexes[p1]])
                {
                    buffer[p] = indexes[p2];
                    sum += inversionsOld[indexes[p2]];
                    p2++;
                }
                else
                {
                    buffer[p] = indexes[p1];
                    inversionsNew[indexes[p1]] += sum;
                    p1++;
                }

                p++;
            }

            while (p1 <= m)
            {
                buffer[p] = indexes[p1];
                inversionsNew[indexes[p1]] += sum;
                p++;
                p1++;
            }

            while (p2 <= r)
            {
                buffer[p] = indexes[p2];
                p++;
                p2++;
            }

            for (int i = l; i <= r; i++)
            {
                indexes[i] = buffer[i - l];
            }
        }
    }
}
