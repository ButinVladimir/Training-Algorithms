using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class HackerlandRadioTransmitters
    {
        public static int Solve(int k, int[] a)
        {
            Array.Sort(a);
            int left = 0;
            int pos;
            int result = 0;
            while (left < a.Length)
            {
                pos = left;
                while (pos < a.Length && a[pos] <= a[left] + k)
                {
                    pos++;
                }
                pos--;
                result++;
                while (left < a.Length && a[left] <= a[pos] + k)
                {
                    left++;
                }
            }

            return result;
        }
    }
}
