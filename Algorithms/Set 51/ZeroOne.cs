using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_51
{
    class ZeroOne
    {
        public static double Solve(string s)
        {
            int n = s.Length;
            int left = 0;
            int right = n - 1;
            double result = 0;

            while (left < right)
            {
                while (left < n && s[left] == '0')
                {
                    left++;
                }

                while (right >= 0 && s[right] == '1')
                {
                    right--;
                }

                if (left < right)
                {
                    result += Math.Sqrt(right - left);
                    left++;
                    right--;
                }
            }

            return result;
        }
    }
}
