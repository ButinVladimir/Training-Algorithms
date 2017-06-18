using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class IceCream
    {
        private const int N = 20000;
        private const int None = -1;
        private static int[] pos = new int[N];

        public static Tuple<int, int> Solve(int[] a, int m)
        {
            Clear();
            int j;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= m)
                {
                    continue;
                }

                j = m - a[i];
                if (pos[j] != None)
                {
                    return new Tuple<int, int>(pos[j], i);
                }

                pos[a[i]] = i;
            }

            return null;
        }

        private static void Clear()
        {
            for (int i = 0; i < N; i++)
            {
                pos[i] = None;
            }
        }
    }
}
