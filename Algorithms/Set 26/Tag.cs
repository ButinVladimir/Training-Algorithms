using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_26
{
    public class Tag
    {
        private List<TagEvent> events;
        private Dictionary<int, List<Tuple<int, int>>> result;

        public Tag(int tagsCount)
        {
            this.TagsCount = tagsCount;
            this.events = new List<TagEvent>();
            this.result = new Dictionary<int, List<Tuple<int, int>>>();
        }

        public int TagsCount { get; private set; }

        public void AddTag(int from, int to, int tag)
        {
            this.events.Add(new TagEvent() { Position = from, Tag = tag, IsOpen = true });
            this.events.Add(new TagEvent() { Position = to, Tag = tag, IsOpen = false });
        }

        public void Build()
        {
            TagEvent[] sortedEvents = this.events.ToArray();
            Array.Sort(sortedEvents);

            int[] openedCount = new int[this.TagsCount];
            int[] openedPosition = new int[this.TagsCount];
            int mask = 0;

            foreach (TagEvent tagEvent in sortedEvents)
            {
                if (tagEvent.IsOpen)
                {
                    openedCount[tagEvent.Tag]++;
                    if (openedCount[tagEvent.Tag] == 1)
                    {
                        openedPosition[tagEvent.Tag] = tagEvent.Position;
                        mask += 1 << tagEvent.Tag;
                    }
                }
                else
                {
                    openedCount[tagEvent.Tag]--;
                    if (openedCount[tagEvent.Tag] == 0)
                    {
                        this.AddResults(mask, tagEvent.Tag, tagEvent.Position, openedPosition);
                        mask -= 1 << tagEvent.Tag;
                    }
                }
            }
        }

        public List<Tuple<int, int>> Query(int[] tags)
        {
            int mask = 0;
            foreach (int tag in tags)
            {
                mask |= 1 << tag;
            }

            if (!this.result.ContainsKey(mask))
            {
                return new List<Tuple<int, int>>();
            }

            return this.result[mask].ToList();
        }

        private void AddResults(int mask, int tag, int closingPosition, int[] openedPosition)
        {
            int tt = 1 << tag;
            int shortmask = mask - tt;
            int position;

            for (int submask = shortmask; ; submask = (submask - 1) & shortmask)
            {
                position = -1;

                for (int i = 0; i < this.TagsCount; i++)
                {
                    if (i == tag || (submask & (1 << i)) > 0)
                    {
                        position = Math.Max(position, openedPosition[i]);
                    }
                }

                if (!this.result.ContainsKey(submask + tt))
                {
                    this.result[submask + tt] = new List<Tuple<int, int>>();
                }
                this.result[submask + tt].Add(new Tuple<int, int>(position, closingPosition));

                if (submask == 0)
                {
                    break;
                }
            }
        }

        private class TagEvent : IComparable<TagEvent>
        {
            public int Position { get; set; }
            public int Tag { get; set; }
            public bool IsOpen { get; set; }

            int IComparable<TagEvent>.CompareTo(TagEvent other)
            {
                if (this.Position != other.Position)
                {
                    return this.Position.CompareTo(other.Position);
                }

                if (this.IsOpen != other.IsOpen)
                {
                    return this.IsOpen.CompareTo(other.IsOpen);
                }

                return this.Tag.CompareTo(other.Tag);
            }
        }
    }
}
