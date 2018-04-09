using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class BigSorting
    {
        public static void Sort(string[] numbers)
        {
            Comparer comparer = new Comparer();
            Array.Sort(numbers, comparer);
        }

        private class Comparer : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                if (x.Length < y.Length)
                {
                    return -1;
                }

                if (x.Length > y.Length)
                {
                    return 1;
                }

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] < y[i])
                    {
                        return -1;
                    }

                    if (x[i] > y[i])
                    {
                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}
