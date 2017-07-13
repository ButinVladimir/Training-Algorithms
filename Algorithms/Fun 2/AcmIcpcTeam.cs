using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class AcmIcpcTeam
    {
        public static Tuple<int, int> Solve(string[] s)
        {
            int n = s.Length;
            int m = s[0].Length;

            int maxRes = 0;
            int count = 0;
            int buffer;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    buffer = 0;

                    for (int k = 0; k < m; k++)
                    {
                        if (s[i][k] == '1' || s[j][k] == '1')
                        {
                            buffer++;
                        }
                    }

                    if (buffer > maxRes)
                    {
                        maxRes = buffer;
                        count = 0;
                    }

                    if (buffer == maxRes)
                    {
                        count++;
                    }
                }
            }

            return new Tuple<int, int>(maxRes, count);
        }
    }
}
