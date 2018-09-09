using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_9
{
    public static class GridlandMetro
    {
        public static long Solve(long n, long m, long[] r, long[] c1, long[] c2)
        {
            Dictionary<long, List<SortEvent>> rows = new Dictionary<long, List<SortEvent>>();
            for (int i = 0; i < r.Length; i++)
            {
                List<SortEvent> row;
                if (!rows.TryGetValue(r[i], out row))
                {
                    row = new List<SortEvent>();
                    rows[r[i]] = row;
                }

                row.Add(new SortEvent() { Position = c1[i], Close = false });
                row.Add(new SortEvent() { Position = c2[i], Close = true });
            }

            long result = n * m;
            long left, counter;
            foreach (List<SortEvent> row in rows.Values)
            {
                SortEvent[] sortedEvents = row.ToArray();
                Array.Sort(sortedEvents);

                counter = 0;
                left = 0;
                foreach (SortEvent e in sortedEvents)
                {
                    if (!e.Close)
                    {
                        counter++;

                        if (counter == 1)
                        {
                            left = e.Position;
                        }
                    }
                    else
                    {
                        counter--;

                        if (counter == 0)
                        {
                            result -= e.Position - left + 1;
                        }
                    }
                }
            }

            return result;
        }

        private class SortEvent : IComparable<SortEvent>
        {
            public long Position { get; set; }
            public bool Close { get; set; }

            int IComparable<SortEvent>.CompareTo(SortEvent other)
            {
                int result = this.Position.CompareTo(other.Position);
                if (result == 0)
                {
                    result = this.Close.CompareTo(other.Close);
                }

                return result;
            }
        }
    }
}
