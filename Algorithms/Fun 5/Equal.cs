using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class Equal
    {
        private const int MaxChocolates = 2000000;
        private static int[] actions;

        static Equal()
        {
            actions = new int[MaxChocolates + 1];
            actions[0] = 0;

            for (int i = 1; i <= MaxChocolates; i++)
            {
                actions[i] = actions[i - 1] + 1;

                if (i >= 3)
                {
                    actions[i] = Math.Min(actions[i], actions[i - 3] + 1);
                }

                if (i >= 5)
                {
                    actions[i] = Math.Min(actions[i], actions[i - 5] + 1);
                }
            }
        }

        public static int Solve(int[] a)
        {
            if (a.Length == 1)
            {
                return 0;
            }

            int result = -1;
            int n = a.Length;
            int sum = a.Sum();
            int d;
            for (int q = Math.Max(a.Max(), sum / n); q <= MaxChocolates; q++)
            {
                d = n * q - sum;
                if (d < 0 || d % (n - 1) != 0)
                {
                    continue;
                }
                if (d > MaxChocolates)
                {
                    break;
                }

                d /= n - 1;

                if (result == -1 || actions[d] < result)
                {
                    result = actions[d];
                }
            }

            return result;
        }
    }
}
