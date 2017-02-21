using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_68
{
    public class BigSorting
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

                return x.CompareTo(y);
            }
        }
    }
}
