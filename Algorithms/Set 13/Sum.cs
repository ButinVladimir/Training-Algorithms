using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_13
{
    public static class Sum
    {
        public static bool Solve(int m, int[] a)
        {
            SortedSet<int> current = new SortedSet<int>();
            SortedSet<int> next = new SortedSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                next.Add(a[i] % m);
                foreach (int cv in current)
                {
                    next.Add((a[i] % m + cv) % m);
                    next.Add(cv);
                }

                current = next;
                next = new SortedSet<int>();

                if (current.Contains(0))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
