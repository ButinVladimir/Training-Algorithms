using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class MigratoryBirds
    {
        public static int Solve(int[] a)
        {
            int[] cnt = new int[5];
            foreach (var v in a)
            {
                cnt[v - 1]++;
            }

            int result = 0;
            for (int i = 0; i < 5; i++)
            {
                if (cnt[i] > cnt[result])
                {
                    result = i;
                }
            }

            return result + 1;
        }
    }
}
