using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class ManasaStones
    {
        public static List<int> Solve(int n, int a, int b)
        {
            List<int> result = new List<int>();

            if (n == 1)
            {
                result.Add(0);
            }
            else if (a == b)
            {
                result.Add((n - 1) * a);
            }
            else
            {
                if (a > b)
                {
                    int buffer = a;
                    a = b;
                    b = buffer;
                }

                for (int i = 0; i < n; i++)
                {
                    result.Add((n - 1 - i) * a + i * b);
                }
            }

            return result;
        }
    }
}
