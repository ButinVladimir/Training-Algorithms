using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class IsFibo
    {
        private const long Max = 100000000000;
        private static SortedSet<long> Numbers;

        static IsFibo()
        {
            Numbers = new SortedSet<long>();

            long n1 = 0;
            long n2 = 1;
            Numbers.Add(n1);
            Numbers.Add(n2);

            while (n2 < Max)
            {
                n2 += n1;
                n1 = n2 - n1;

                Numbers.Add(n2);
            }
        }

        public static bool Is(long n)
        {
            return Numbers.Contains(n);
        }
    }
}
