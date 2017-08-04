using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class Sticks
    {
        public static List<int> Solve(int[] a)
        {
            Array.Sort(a);

            List<int> result = new List<int>();

            int left = 0;
            int right;
            while (left < a.Length)
            {
                right = left;
                while (right < a.Length && a[left] == a[right])
                {
                    right++;
                }

                result.Add(a.Length - left);
                left = right;
            }

            return result;
        }
    }
}
