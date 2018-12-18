using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public class TowerBreakers
    {
        private const int M = 1000000;
        private static readonly bool[] results = new bool[M + 1];

        static TowerBreakers()
        {
            for (int i = 2; i <= M; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    if (i % j != 0)
                    {
                        continue;
                    }

                    if (!results[j] || !results[i % j])
                    {
                        results[i] = true;
                        break;
                    }
                }
            }
        }

        public bool Solve(int n, int m)
        {
            if (results[m] && n % 2 == 1)
            {
                return true;
            }

            if (!results[m] && n % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
