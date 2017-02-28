using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_34
{
    public class OneSequence
    {
        public static int Solve(int k, int[] input)
        {
            int n = input.Length;
            int left = 0;
            int zeros = 0;
            int result = 0;

            for (int right = 0; right < n; right++)
            {
                if (input[right] == 0)
                {
                    zeros++;
                }

                while (zeros > k)
                {
                    if (input[left] == 0)
                    {
                        zeros--;
                    }

                    left++;
                }

                if (right >= left)
                {
                    result = Math.Max(result, right - left + 1);
                }
            }

            return result;
        }
    }
}
