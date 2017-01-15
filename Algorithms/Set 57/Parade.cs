using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_57
{
    class Parade
    {
        public int N { get; set; }
        public int[] L { get; set; }
        public int[] R { get; set; }

        public int Solve()
        {
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += L[i] - R[i];
            }

            int result = Math.Abs(sum);
            int column = 0;
            int nextSum;

            for (int i = 0; i < N; i++)
            {
                nextSum = Math.Abs(sum - 2 * L[i] + 2 * R[i]);

                if (nextSum > result)
                {
                    column = i + 1;
                    result = nextSum;
                }
            }

            return column;
        }
    }
}
