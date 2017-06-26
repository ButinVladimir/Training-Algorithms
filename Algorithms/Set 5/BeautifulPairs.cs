using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_5
{
    public static class BeautifulPairs
    {
        private const int N = 1002;

        public static int Solve(int[] a, int[] b)
        {
            int[] countA = new int[N];
            int[] countB = new int[N];

            for (int i = 0; i < a.Length; i++)
            {
                countA[a[i]]++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                countB[b[i]]++;
            }

            int pairs = 0;
            for (int i = 0; i < N; i++)
            {
                pairs += Math.Min(countA[i], countB[i]);
            }

            int p1, p2;
            int result = 0;
            for (int i = 0; i < N; i++)
            {
                if (countB[i] == 0)
                {
                    continue;
                }

                p1 = pairs;
                if (countB[i] <= countA[i])
                {
                    p1--;
                }

                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    p2 = p1;
                    if (countB[j] < countA[j])
                    {
                        p2++;
                    }

                    result = Math.Max(result, p2);
                }
            }

            return result;
        }
    }
}
