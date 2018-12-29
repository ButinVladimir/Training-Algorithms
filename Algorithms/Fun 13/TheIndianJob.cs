using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class TheIndianJob
    {
        private const int N = 10001;
        private static bool[] visited = new bool[N];

        public static bool Solve(int[] a, int g)
        {
            int sum = a.Sum();
            if (sum <= g)
            {
                return true;
            }

            for (int i = 0; i < N; i++)
            {
                visited[i] = false;
            }

            visited[0] = true;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = N - 1; j >= 0; j--)
                {
                    if (visited[j])
                    {
                        visited[j + a[i]] = true;
                    }
                }
            }

            for (int i = 0; i < N - 1; i++)
            {
                if (visited[i] && (sum - i) <= g && i <= g)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
