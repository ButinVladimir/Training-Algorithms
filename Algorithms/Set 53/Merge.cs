using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_53
{
    class Merge
    {
        public static void Solve(int n, int[] a, int[] b)
        {
            if (a.Length != 2 * n)
            {
                throw new Exception("Invalid length of array a");
            }

            if (b.Length != n)
            {
                throw new Exception("Invalid length of array b");
            }

            int resultCounter = (2 * n) - 1;
            int counterA = n - 1;
            int counterB = n - 1;

            while (counterA >= 0 && counterB >= 0)
            {
                if (a[counterA] > b[counterB])
                {
                    a[resultCounter] = a[counterA];
                    counterA--;
                }
                else
                {
                    a[resultCounter] = b[counterB];
                    counterB--;
                }

                resultCounter--;
            }

            while (counterB >= 0)
            {
                a[resultCounter] = b[counterB];
                counterB--;
                resultCounter--;
            }
        }
    }
}
