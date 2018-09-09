using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class FindDigits
    {
        public static int Solve(int number)
        {
            string numberAsString = number.ToString();
            int result = 0;

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int d = Convert.ToInt32(numberAsString.Substring(i, 1));
                if (d > 0 && number % d == 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
