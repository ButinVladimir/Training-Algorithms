using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_70
{
    public class Bathroom
    {
        public static Tuple<long, long> Solve(long n, long k)
        {
            bool[] visited = new bool[n + 2];
            visited[0] = true;
            visited[n + 1] = true;

            long nextP = -1;
            long l, r;
            long max, min;

            for (long visitor = 0; visitor < k; visitor++)
            {
                long minLR = -1;
                long maxLR = -1;
                nextP = -1;

                for (long i = 1; i <= n; i++)
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

            return new Tuple<long, long>(max, min);
        }

        public static Tuple<long, long> SolveMed(long n, long k)
        {
            SortedSet<Segment> segments = new SortedSet<Segment>();
            segments.Add(new Segment() { Start = 0, Finish = n + 1 });

            long min = 0, max = 0, mid;
            long l, r;
            for (long visitor = 0; visitor < k; visitor++)
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

            return new Tuple<long, long>(max, min);
        }

        public static Tuple<long, long> SolveHard(long n, long k)
        {
            SortedDictionary<long, long> segments = new SortedDictionary<long, long>(new ReverseComparer());
            segments.Add(n, 1);

            while (k > 0)
            {
                foreach (var kvp in segments)
                {
                    if (kvp.Value >= k)
                    {
                        return new Tuple<long, long>(kvp.Key / 2, (kvp.Key - 1) / 2);
                    }

                    segments.Remove(kvp.Key);
                    k -= kvp.Value;
                    AddSegments(kvp.Key / 2, kvp.Value, segments);
                    AddSegments((kvp.Key - 1) / 2, kvp.Value, segments);
                    break;
                }
            }

            return null;
        }

        private static void AddSegments(long key, long value, SortedDictionary<long, long> segments)
        {
            if (segments.ContainsKey(key))
            {
                segments[key] += value;
            }
            else
            {
                segments[key] = value;
            }
        }

        private class Segment : IComparable<Segment>
        {
            public long Start { get; set; }
            public long Finish { get; set; }

            int IComparable<Segment>.CompareTo(Segment other)
            {
                long length = this.Finish - this.Start;
                long otherLength = other.Finish - other.Start;

                if (length != otherLength)
                {
                    return otherLength.CompareTo(length);
                }

                return this.Start.CompareTo(other.Start);
            }
        }

        private class ReverseComparer : IComparer<long>
        {
            int IComparer<long>.Compare(long x, long y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
