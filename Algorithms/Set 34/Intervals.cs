using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_34
{
    public class Intervals
    {
        public static List<Tuple<int, int>> Solve(IList<Tuple<int, int>> list1, IList<Tuple<int, int>> list2)
        {
            List<IntervalEvent> eventsList = new List<IntervalEvent>();

            AddEventsToList(list1, eventsList);
            AddEventsToList(list2, eventsList);

            IntervalEvent[] events = eventsList.ToArray();
            Array.Sort(events);

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            int opened = 0;
            int leftmost = 0;

            for (int i = 0; i < events.Length; i++)
            {
                if (!events[i].IsClosing)
                {
                    if (opened == 0)
                    {
                        leftmost = events[i].Position;
                    }

                    opened++;
                }
                else
                {
                    opened--;
                    if (opened == 0)
                    {
                        result.Add(new Tuple<int, int>(leftmost, events[i].Position));
                    }
                }
            }

            return result;
        }

        private static void AddEventsToList(IList<Tuple<int, int>> list, IList<IntervalEvent> eventsList)
        {
            foreach (var interval in list)
            {
                eventsList.Add(new IntervalEvent()
                {
                    IsClosing = false,
                    Position = interval.Item1
                });

                eventsList.Add(new IntervalEvent()
                {
                    IsClosing = true,
                    Position = interval.Item2
                });
            }
        }

        private class IntervalEvent: IComparable<IntervalEvent>
        {
            public bool IsClosing { get; set; }

            public int Position { get; set; }

            public int CompareTo(IntervalEvent other)
            {
                if (this.Position != other.Position)
                {
                    return this.Position.CompareTo(other.Position);
                }

                return this.IsClosing.CompareTo(other.IsClosing);
            }
        }
    }
}
