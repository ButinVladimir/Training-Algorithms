using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_67
{
    class Birds
    {
        public static int Solve(int[] birds)
        {
            int[] occurences = new int[5];
            for (int i = 0; i < birds.Length; i++)
            {
                occurences[birds[i] - 1]++;
            }

            int result = 0;
            for (int i = 0; i < 5; i++)
            {
                if (occurences[i] > occurences[result])
                {
                    result = i;
                }
            }

            return result + 1;
        }
    }
}
