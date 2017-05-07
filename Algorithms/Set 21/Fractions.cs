using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_21
{
    public static class Fractions
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            int min = a[0];

            for (int i = 0; i < a.Length; i++)
            {
                result += a[i];
                min = Math.Min(min, a[i]);
            }

            int currentResult;
            bool can;

            for (int divider = 1; divider <= min; divider++)
            {
                currentResult = 0;
                can = true;

                for (int i = 0; i < a.Length; i++)
                {
                    int l = a[i] / divider;

                    while (l > 0 && a[i] / l <= divider)
                    {
                        l--;
                    }

                    while (l == 0 || a[i] / l > divider)
                    {
                        l++;
                    }

                    if (a[i] / l == divider)
                    {
                        currentResult += l;
                    }
                    else
                    {
                        can = false;
                        break;
                    }
                }

                if (can)
                {
                    result = Math.Min(result, currentResult);
                }
            }

            return result;
        }
    }
}
