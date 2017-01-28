using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_41
{
    class Sheep
    {
        const int Ten = 10;

        public static long Solve(long start)
        {
            if (start == 0)
            {
                return -1;
            }

            bool[] was = new bool[10];
            for (int i = 0;i<Ten;i++)
            {
                was[i] = false;
            }

            long number = start;
            while (!Add(number, was))
            {
                number += start;
            }

            return number;
        }

        private static bool Add(long number, bool[] was)
        {
            while (number > 0)
            {
                was[number % 10] = true;
                number /= 10;
            }
            
            for (int i =0;i<Ten;i++)
            {
                if (!was[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
