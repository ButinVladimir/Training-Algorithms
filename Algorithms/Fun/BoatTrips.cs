using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    public class BoatTrips
    {
        public static bool Solve(int c, int m, int[] p)
        {
            int max = c * m;

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] > max)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
