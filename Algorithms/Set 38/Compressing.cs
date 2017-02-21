using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_38
{
    public class Compressing
    {
        private const int LETTERS = 26;

        public static long Solve(int n, int q, string[] from, char[] to)
        {
            long[] current = new long[LETTERS];
            long[] next = new long[LETTERS];
            current[0] = 1;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    next[from[j][0] - 'a'] += current[to[j] - 'a'];
                }

                for (int j = 0; j < LETTERS; j++)
                {
                    current[j] = next[j];
                    next[j] = 0;
                }
            }

            long result = 0;
            for (int i = 0; i < LETTERS; i++)
            {
                result += current[i];
            }

            return result;
        }
    }
}
