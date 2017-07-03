using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_72
{
    public static class Cipher
    {
        public static string Solve(int n, int k, string input)
        {
            int[] values = new int[n];

            int prefix = 0;
            int symbol;
            for (int i = 0; i < n; i++)
            {
                if (i >= k)
                {
                    prefix ^= values[i - k];
                }

                symbol = input[i] == '0' ? 0 : 1;

                values[i] = symbol ^ prefix;
                prefix ^= values[i];
            }

            return string.Join(string.Empty, values);
        }
    }
}
