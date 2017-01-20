using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_53
{
    class LastDigitPower
    {
        public static int Solve(int b, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            int sqrt = Solve(b, power / 2);
            int result = (sqrt * sqrt) % 10;

            if (power % 2 == 1)
            {
                result = (result * b) % 10;
            }

            return result;
        }
    }
}
