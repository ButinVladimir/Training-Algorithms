using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Equal
    {
        public static long Solve(long[] a)
        {
            Array.Sort(a);

            long result = 0;
            long add = 0;

            for (int i =1;i<a.Length;i++)
            {
                a[i] += add;

                result += Update(a, i, 5, ref add) + Update(a, i, 2, ref add) + Update(a, i, 1, ref add);
            }

            return result;
        }

        public static long Update(long[] a, int position, long val, ref long add)
        {
            long buffer = (a[position] - a[position - 1]) / val;
            add += buffer * val;
            a[position - 1] += buffer * val;

            return buffer;
        }
    }
}
