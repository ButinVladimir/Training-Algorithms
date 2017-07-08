using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_73
{
    public static class ChiefHopper
    {
        public static long Solve(long[] h)
        {
            long current = -1;
            long step = 100000;
            long next;
            int n = h.Length;
            long energy;
            bool can;

            long max = h[0];
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, h[i]);
            }

            while (step > 0)
            {
                next = current + step;
                energy = next;
                can = true;

                for (int i = 0; i < n; i++)
                {
                    if (energy >= max)
                    {
                        break;
                    }

                    if (energy < 0)
                    {
                        can = false;

                        break;
                    }

                    if (energy >= h[i])
                    {
                        energy += energy - h[i];
                    }
                    else
                    {
                        energy -= h[i] - energy;
                    }
                }

                if (energy < 0)
                {
                    can = false;
                }

                if (!can)
                {
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return current + 1;
        }
    }
}
