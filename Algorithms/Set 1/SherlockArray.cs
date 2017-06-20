using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_1
{
    public static class SherlockArray
    {
        public static bool Solve(long[] a)
        {
            long right = 0;
            for (int i = 0; i < a.Length; i++)
            {
                right += a[i];
            }

            long left = 0;
            for (int i = 0; i < a.Length; i++)
            {
                right -= a[i];

                if (left == right)
                {
                    return true;
                }

                left += a[i];
            }

            return false;
        }
    }
}
