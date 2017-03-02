using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_32
{
    public class Frequent
    {
        public static int SolveN2(int n, int[] a)
        {
            int length = n / 2 + (n % 2 == 1 ? 1 : 0);

            if (GetLength(a[n / 2], a) <= length)
            {
                throw new Exception("Invalid array");
            }

            return a[n / 2];
        }

        public static int SolveN4(int n, int[] a)
        {
            int length = n / 4 + (n % 4 > 0 ? 1 : 0);

            if (GetLength(a[n / 2], a) > length)
            {
                return a[n / 2];
            }

            if (GetLength(a[n / 4], a) > length)
            {
                return a[n / 4];
            }

            if (GetLength(a[3 * n / 4], a) > length)
            {
                return a[3 * n / 4];
            }

            throw new Exception("Invalid array");
        }

        private static int GetLength(int value, int[] a)
        {
            int start, finish, step, next;

            start = -1;
            step = a.Length + 1;
            while (step > 0)
            {
                next = start + step;

                if (next >= 0 && next < a.Length && a[next] < value)
                {
                    start = next;
                }
                else
                {
                    step /= 2;
                }
            }

            start++;
            if (start >= a.Length || a[start] != value)
            {
                return 0;
            }

            finish = -1;
            step = a.Length + 1;
            while (step > 0)
            {
                next = finish + step;

                if (next >= 0 && next < a.Length && a[next] <= value)
                {
                    finish = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return finish - start + 1;
        }
    }
}
