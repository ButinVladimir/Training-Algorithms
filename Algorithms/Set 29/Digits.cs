using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_29
{
    public static class Digits
    {
        public static int Solve(decimal a)
        {
            return GetBeforeDot(a) + GetAfterDot(a);
        }

        private static int GetBeforeDot(decimal a)
        {
            int result = 0;
            
            a = Math.Truncate(a);
            if (a == 0)
            {
                result++;
            }

            while (a > 0)
            {
                a = Math.Truncate(a / 10);
                result++;
            }

            return result;
        }

        private static int GetAfterDot(decimal a)
        {
            int result = 0;

            a = a - Math.Truncate(a);
            while (a > 0)
            {
                a = a * 10;
                a = a - Math.Truncate(a);
                result++;
            }

            return result;
        }
    }
}
