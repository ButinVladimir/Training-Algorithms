using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_70
{
    public class Bathroom
    {
        public static Tuple<int, int> Solve(int n, int k)
        {
            bool[] visited = new bool[n + 2];
            visited[0] = true;
            visited[n + 1] = true;

            int nextP = -1;
            int l, r;
            int max, min;

            for (int visitor = 0; visitor < k; visitor++)
            {
                int minLR = -1;
                int maxLR = -1;
                nextP = -1;

                for (int i = 1; i <= n; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    l = i - 1;
                    while (!visited[l])
                    {
                        l--;
                    }

                    r = i + 1;
                    while (!visited[r])
                    {
                        r++;
                    }

                    l = i - l - 1;
                    r = r - i - 1;
                    max = Math.Max(l, r);
                    min = Math.Min(l, r);

                    if (min > minLR || min == minLR && max > maxLR)
                    {
                        maxLR = max;
                        minLR = min;
                        nextP = i;
                    }
                }

                visited[nextP] = true;
            }

            l = nextP - 1;
            while (!visited[l])
            {
                l--;
            }

            r = nextP + 1;
            while (!visited[r])
            {
                r++;
            }

            l = nextP - l - 1;
            r = r - nextP - 1;
            max = Math.Max(l, r);
            min = Math.Min(l, r);

            return new Tuple<int, int>(max, min);
        }

        public static Tuple<int, int> SolveMed(int n, int k)
        {
            SortedSet<Segment> segments = new SortedSet<Segment>();
            segments.Add(new Segment() { Start = 0, Finish = n + 1 });

            int min = 0, max = 0, mid;
            int l, r;
            for (int visitor = 0; visitor < k; visitor++)
            {
                Segment first = null;
                foreach (var segment in segments)
                {
                    first = segment;
                    break;
                }

                mid = (first.Finish + first.Start) / 2;
                l = mid - first.Start - 1;
                r = first.Finish - mid - 1;
                max = Math.Max(l, r);
                min = Math.Min(l, r);

                if (mid > first.Start + 1)
                {
                    segments.Add(new Segment() { Start = first.Start, Finish = mid });
                }

                if (first.Finish > mid + 1)
                {
                    segments.Add(new Segment() { Start = mid, Finish = first.Finish });
                }

                segments.Remove(first);
            }

            return new Tuple<int, int>(max, min);
        }

        private class Segment : IComparable<Segment>
        {
            public int Start { get; set; }
            public int Finish { get; set; }

            int IComparable<Segment>.CompareTo(Segment other)
            {
                int length = this.Finish - this.Start;
                int otherLength = other.Finish - other.Start;

                if (length != otherLength)
                {
                    return otherLength.CompareTo(length);
                }

                return this.Start.CompareTo(other.Start);
            }
        }
    }
}
