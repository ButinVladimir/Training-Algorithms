using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class LarrysArray
    {
        public static bool Solve(int[] a)
        {
            int pos;
            for (int i = 0; i < a.Length - 1; i++)
            {
                pos = i;
                while (a[pos] != i + 1)
                {
                    pos++;
                }

                int b;
                while (pos > i + 1)
                {
                    a[pos] = a[pos - 1];
                    a[pos - 1] = a[pos - 2];
                    a[pos - 2] = i + 1;
                    pos -= 2;
                }
                if (pos > i && pos < a.Length - 1)
                {
                    a[pos] = a[pos + 1];
                    a[pos + 1] = a[pos - 1];
                    a[pos - 1] = i + 1;
                    pos--;
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != i + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
