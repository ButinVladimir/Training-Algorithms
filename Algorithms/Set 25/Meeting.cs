using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_25
{
    public class Meeting
    {
        private List<MeetingEvent> events;

        public Meeting()
        {
            this.events = new List<MeetingEvent>();
        }

        public void AddEvent(int start, int finish)
        {
            this.events.Add(new MeetingEvent() { Time = start, Finish = false });
            this.events.Add(new MeetingEvent() { Time = finish, Finish = true });
        }

        public int Find(int t)
        {
            MeetingEvent[] eventArray = this.events.ToArray();
            Array.Sort(eventArray);

            if (eventArray.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = 0;
            int opened = 0;
            int prev = 0;
            int prevOpened = 0;

            while (left < eventArray.Length)
            {
                for (right = left; right < eventArray.Length && eventArray[left].Time == eventArray[right].Time; right++)
                {
                    if (eventArray[right].Finish)
                    {
                        opened--;
                    }
                    else
                    {
                        opened++;
                    }
                }

                if (prevOpened == 0 && eventArray[left].Time - prev >= t)
                {
                    return prev;
                }

                prevOpened = opened;
                prev = eventArray[left].Time;
                left = right;
            }
            return eventArray[left - 1].Time;
        }


        private class MeetingEvent : IComparable<MeetingEvent>
        {
            public int Time { get; set; }
            public bool Finish { get; set; }

            int IComparable<MeetingEvent>.CompareTo(MeetingEvent other)
            {
                int result = this.Time.CompareTo(other.Time);
                if (result == 0)
                {
                    result = this.Finish.CompareTo(other.Finish);
                }

                return result;
            }
        }
    }

    [TestClass]
    public class MeetingTest
    {
        [TestMethod]
        public void Test1()
        {
            Meeting meeting = new Meeting();

            Assert.AreEqual(0, meeting.Find(5));
        }

        [TestMethod]
        public void Test2()
        {
            Meeting meeting = new Meeting();

            meeting.AddEvent(10, 15);

            Assert.AreEqual(0, meeting.Find(5));
        }

        [TestMethod]
        public void Test3()
        {
            Meeting meeting = new Meeting();

            meeting.AddEvent(1, 7);
            meeting.AddEvent(5, 8);
            meeting.AddEvent(15, 20);

            Assert.AreEqual(8, meeting.Find(3));
        }

        [TestMethod]
        public void Test4()
        {
            Meeting meeting = new Meeting();

            meeting.AddEvent(1, 7);
            meeting.AddEvent(5, 13);
            meeting.AddEvent(15, 20);

            Assert.AreEqual(20, meeting.Find(3));
        }
    }
}

