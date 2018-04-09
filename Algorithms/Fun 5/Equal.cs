using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class Equal
    {
        private const int MaxChocolates = 2000;
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
            Array.Sort(a);
            int min = a[0];

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += actions[a[i] - min];
            }

            int buffer;
            for (int step = 1; step <= 30; step++)
            {
                buffer = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    buffer += actions[a[i] - min + step];
                }

                result = Math.Min(result, buffer);
            }

            return result;
        }
    }
}
