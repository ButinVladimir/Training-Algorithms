using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class JumpingCloudsRevisited
    {
        public static int Solve(int n, int k, int[] c)
        {
            int pos = 0;
            int result = 100;

            do
            {
                pos = (pos + k) % n;

                if (c[pos] == 1)
                {
                    result -= 2;
                }

                result--;
            } while (pos != 0);

            return result;
        }
    }
}
