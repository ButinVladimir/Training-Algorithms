using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class MarsExploration
    {
        public static int Solve(string s)
        {
            int m = 0;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (m == 1 && s[i] != 'O' || m != 1 && s[i] != 'S')
                {
                    result++;
                }

                m = (m + 1) % 3;
            }

            return result;
        }
    }
}
