using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class LeftRotation
    {
        public static int[] Solve(int[] array, int d)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length - d; i++)
            {
                result[i] = array[i + d];
            }

            for (int i = 0; i < d; i++)
            {
                result[array.Length - d + i] = array[i];
            }

            return result;
        }
    }
}
