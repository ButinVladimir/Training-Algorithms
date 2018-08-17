using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class BeautifulDaysAtTheMovies
    {
        public static int Solve(int l, int r, int k)
        {
            int result = 0;
            for (int i = l; i <= r; i++)
            {
                if (Check(i, k))
                {
                    result++;
                }
            }

            return result;
        }

        private static bool Check(int value, int k)
        {
            int reversed = Convert.ToInt32(new string(value.ToString().Reverse().ToArray()));

            return (Math.Abs(value - reversed) % k) == 0;
        }
    }
}
