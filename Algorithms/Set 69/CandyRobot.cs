using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_69
{
    public class CandyRobot
    {
        public static int Solve(int n, int t, int[] c)
        {
            int result = 0;
            int current = n;
            for (int i = 0; i < t - 1; i++)
            {
                current -= c[i];

                if (current < 5)
                {
                    result += n - current;
                    current = n;
                }
            }

            return result;
        }
    }
}
