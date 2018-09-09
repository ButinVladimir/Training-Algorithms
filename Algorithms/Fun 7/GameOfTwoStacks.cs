using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class GameOfTwoStacks
    {
        public static long Solve(long[] a, long[] b, long x)
        {
            int lengthA = a.Length;
            long[] sumA = new long[lengthA];
            long result = 0;

            for (int i = 0; i < lengthA; i++)
            {
                sumA[i] = a[i] + (i > 0 ? sumA[i - 1] : 0);

                if (sumA[i] <= x)
                {
                    result = i + 1;
                }
            }

            long sumB = 0;
            for (int i = 0; i < b.Length; i++)
            {
                sumB += b[i];

                if (sumB > x)
                {
                    break;
                }

                int step = lengthA;
                int position = -1;
                int nextPosition;
                while (step > 0)
                {
                    nextPosition = position + step;
                    if (nextPosition < lengthA && sumB + sumA[nextPosition] <= x)
                    {
                        position = nextPosition;
                    } else
                    {
                        step /= 2;
                    }
                }

                result = Math.Max(result, position + 1 + i + 1);
            }

            return result;
        }
    }
}
