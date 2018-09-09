using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_6
{
    public static class NewYearChaos
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int n = a.Length;
            bool[] b = new bool[n];

            for (int i = 0; i < n; i++)
            {
                int diff = -1;
                for (int j = 0; j <= 2 && (i + j) < n; j++)
                {
                    if (a[i + j] == i + 1)
                    {
                        diff = j;
                        break;
                    }
                }

                if (diff == -1)
                {
                    return -1;
                }

                result += diff;

                while (diff > 0)
                {
                    if (b[a[i + diff - 1] - 1])
                    {
                        return -1;
                    }

                    b[a[i + diff - 1] - 1] = true;
                    a[i + diff] = a[i + diff - 1];
                    diff--;
                }
                a[i] = i + 1;
            }

            return result;
        }
    }
}
