using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_8
{
    public static class HalloweenSale
    {
        public static long Solve(long p, long d, long m, long s)
        {
            long pos = -1;
            long nextPos;
            long step = 1;
            long mx = (long) Math.Floor(((decimal)p - m) / d);
            long sum;

            while (step > 0)
            {
                nextPos = pos + step;
                if (nextPos <= mx + 1)
                {
                    sum = (p + (p - (nextPos - 1) * d)) * nextPos / 2;
                }
                else
                {
                    sum = (p + (p - mx * d)) * (mx + 1) / 2 + m * (nextPos - mx - 1);
                }

                if (sum <= s)
                {
                    pos = nextPos;
                    step *= 2;
                }
                else
                {
                    step /= 2;
                }
            }

            return pos;
        }
    }
}
