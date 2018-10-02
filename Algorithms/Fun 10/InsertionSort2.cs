using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class InsertionSort2
    {
        public static string Solve(int[] a)
        {
            List<string> result = new List<string>();
            int j, v;
            for (int i = 1; i < a.Length; i++)
            {
                j = i;
                v = a[i];
                while (j > 0 && a[j - 1] > v)
                {
                    a[j] = a[j - 1];
                    j--;
                }

                a[j] = v;
                result.Add(string.Join(" ", a));
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
