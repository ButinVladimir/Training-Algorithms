using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class CountingSort2
    {
        public static int[] Solve(int[] a)
        {
            int[] count = new int[100];
            for (int i = 0; i < a.Length; i++)
            {
                count[a[i]]++;
            }

            int[] result = new int[a.Length];
            int position = 0;
            int number = 0;
            while (position < a.Length)
            {
                if (count[number] > 0)
                {
                    count[number]--;
                    result[position] = number;
                    position++;
                }
                else
                {
                    number++;
                }
            }

            return result;
        }
    }
}
