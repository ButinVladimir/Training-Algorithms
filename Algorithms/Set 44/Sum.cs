using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_44
{
    using System.Collections;

    class Sum
    {
        /// <summary>
        /// The guaranteed solution.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="targetSum">
        /// The target sum.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Tuple<long, long, long>> Solve(long[] a, long[] b, long[] c, long targetSum)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);
            List<Tuple<long, long, long>> result = new List<Tuple<long, long, long>>();
            
            for (int p1 = 0; p1 < a.Length; p1++)
            {
                for (int p2 = 0; p2 < b.Length; p2++)
                {
                    int p3 = FindStart(c, targetSum - a[p1] - b[p2]);

                    while (p3 >= 0 && p3 < c.Length && a[p1] + b[p2] + c[p3] == targetSum)
                    {
                        result.Add(new Tuple<long, long, long>(a[p1], b[p2], c[p3]));
                        p3++;
                    }
                }
            }

            return result;
        }
        public static List<Tuple<long, long, long>> SolveAnotherWay(long[] a, long[] b, long[] c, long targetSum)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);
            List<Tuple<long, long, long>> result = new List<Tuple<long, long, long>>();

            for (int p1 = 0; p1 < a.Length; p1++)
            {
                int p2 = 0;
                int p3 = c.Length - 1;

                while (p2 < b.Length && p3 >= 0)
                {
                    if (a[p1] + b[p2] + c[p3] > targetSum)
                    {
                        p3--;
                    }
                    else if (a[p1] + b[p2] + c[p3] < targetSum)
                    {
                        p2++;
                    }
                    else
                    {
                        int c2 = p2;
                        while (c2 < b.Length && b[p2] == b[c2])
                        {
                            c2++;
                        }

                        int c3 = p3;
                        while (c3 >= 0 && c[p3] == c[c3])
                        {
                            c3--;
                        }

                        int count = (c2 - p2) * (p3 - c3);
                        for (int i = 0; i < count; i++)
                        {
                            result.Add(new Tuple<long, long, long>(a[p1], b[p2], c[p3]));
                        }

                        p2 = c2;
                        p3 = c3;
                    }
                }
            }

            return result;
        }

        private static int FindStart(long[] a, long number)
        {
            int current = -1;
            int step = a.Length;
            int next;

            while (step > 0)
            {
                next = current + step;
                
                if (next < a.Length && next >= 0 && a[next] < number)
                {
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return current + 1;
        }
    }
}
