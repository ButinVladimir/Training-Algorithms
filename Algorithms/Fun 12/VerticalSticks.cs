using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class VerticalSticks
    {
        private const int N = 50;

        public static double Solve(int[] a)
        {
            Array.Sort(a);

            int less, same, more;
            int[] counts = new int[N];
            double result = 0;
            int left = 0;
            int right;

            while (left < a.Length)
            {
                right = left;
                while (right < a.Length && a[right] == a[left])
                {
                    right++;
                }

                less = left;
                same = right - left;
                more = a.Length - right;

                for (int len = 0; len <= less; len++)
                {
                    Decompose(same, counts, 1);
                    Decompose(len + 1, counts, 1);
                    for (int i = less - len + 1; i <= less; i++)
                    {
                        Decompose(i, counts, 1);
                    }

                    for (int i = a.Length - len; i <= a.Length; i++)
                    {
                        Decompose(i, counts, -1);
                    }

                    result += Compose(counts);

                    if (same - 1 + more > 0)
                    {
                        Decompose(same, counts, 1);
                        Decompose(len + 1, counts, 1);
                        Decompose(a.Length - 2 - len + 1, counts, 1);
                        Decompose(more + same - 1, counts, 1);

                        for (int i = less - len + 1; i <= less; i++)
                        {
                            Decompose(i, counts, 1);
                        }

                        for (int i = a.Length - len - 1; i <= a.Length; i++)
                        {
                            Decompose(i, counts, -1);
                        }

                        result += Compose(counts);
                    }
                }

                left = right;
            }

            return result;
        }

        private static void Decompose(int value, int[] counts, int mod)
        {
            for (int i = 2; i < N && value > 1; i++)
            {
                while (value % i == 0)
                {
                    counts[i] += mod;
                    value /= i;
                }
            }
        }

        private static double Compose(int[] counts)
        {
            double result = 1;

            for (int i = 2; i < N; i++)
            {
                while (counts[i] > 0)
                {
                    result *= i;
                    counts[i]--;
                }

                while (counts[i] < 0)
                {
                    result /= i;
                    counts[i]++;
                }
            }

            return result;
        }
    }

    public static class VerticalSticksNaive
    {
        private static int n;
        private static int[] vals;
        private static int[] buffer;
        private static bool[] visited;

        public static double Solve(int[] a)
        {
            n = a.Length;
            buffer = new int[n];
            visited = new bool[n];
            vals = a;

            double result = Visit(0);
            for (int i=1;i<=n;i++)
            {
                result /= i;
            }

            return result;
        }

        private static double Visit(int pos)
        {
            double result = 0;

            if (pos == n)
            {
                for (int i = 0; i < n; i++)
                {
                    int j = i - 1;
                    while (j >= 0 && buffer[j] < buffer[i])
                    {
                        j--;
                    }

                    result += i - j;
                }

                return result;
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    buffer[pos] = vals[i];
                    result += Visit(pos + 1);
                    visited[i] = false;
                }
            }

            return result;
        }
    }
}
