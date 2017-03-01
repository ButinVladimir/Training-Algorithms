using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_33
{
    public class Intervals
    {
        public static List<Tuple<int, int>> Solve(int[] a)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            int left = 0;
            int right = 0;
            while (left < a.Length)
            {
                right = left;
                while (right < a.Length && a[left] == a[right])
                {
                    right++;
                }

                result.Add(new Tuple<int, int>(left, right - 1));
                left = right;
            }

            return result;
        }
    }
}
