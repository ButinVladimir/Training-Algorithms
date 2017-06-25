using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public static class SherlockBeast
    {
        public static string Solve(int n)
        {
            int fives = 0;
            int maxFives = -1;

            while (fives <= n)
            {
                if ((n - fives) % 5 == 0)
                {
                    maxFives = fives;
                }

                fives += 3;
            }

            if (maxFives == -1)
            {
                return "-1";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < maxFives; i++)
            {
                sb.Append('5');
            }

            for (int i = 0; i < n - maxFives; i++)
            {
                sb.Append('3');
            }

            return sb.ToString();
        }
    }
}
