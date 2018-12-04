using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class BirthdayChocolate
    {
        public static int Solve(int[] a, int d, int m)
        {
            int result = 0;
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                sum += a[i];
            }

            if (sum == d)
            {
                result++;
            }
            for (int i = m; i < a.Length; i++)
            {
                sum += a[i] - a[i - m];
                if (sum == d)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
