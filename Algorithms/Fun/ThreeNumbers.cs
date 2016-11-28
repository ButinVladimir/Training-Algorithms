using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class ThreeNumbers
    {
        static private int Sum(int[] array, int p1, int p2, int p3)
        {
            return array[p1] + array[p2] + array[p3];
        }

        static public Tuple<int, int, int> Find(int[] array)
        {
            Array.Sort(array);

            int n = array.Length, p1, p3, sum;

            for (int p2 = 1; p2 < n - 1; p2++)
            {
                p1 = p2 - 1;
                p3 = p2 + 1;
                
                while (p1 >= 0 && p3 < n)
                {
                    sum = Sum(array, p1, p2, p3);
                    if (sum > 0)
                    {
                        p1--;
                    } else
                    if (sum < 0)
                    {
                        p3++;
                    } else
                    {
                        return new Tuple<int, int, int>(array[p1], array[p2], array[p3]);
                    }
                }
            }

            return null;
        }
    }
}
