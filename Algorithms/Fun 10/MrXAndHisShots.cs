using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public class MrXAndHisShots
    {
        public static long Solve(int[] a, int[] b, int[] c, int[] d)
        {
            SortedDictionary<int, QueueEvent> events = new SortedDictionary<int, QueueEvent>();
            QueueEvent evt;

            for (int i = 0; i < a.Length; i++)
            {
                if (!events.TryGetValue(a[i], out evt))
                {
                    evt = new QueueEvent();
                    events[a[i]] = evt;
                }

                evt.NewShots++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!events.TryGetValue(b[i], out evt))
                {
                    evt = new QueueEvent();
                    events[b[i]] = evt;
                }

                evt.LeaveShots++;
            }

            for (int i = 0; i < c.Length; i++)
            {
                if (!events.TryGetValue(c[i], out evt))
                {
                    evt = new QueueEvent();
                    events[c[i]] = evt;
                }

                evt.NewPlayers++;
            }

            for (int i = 0; i < d.Length; i++)
            {
                if (!events.TryGetValue(d[i], out evt))
                {
                    evt = new QueueEvent();
                    events[d[i]] = evt;
                }

                evt.LeavePlayers++;
            }

            int result = 0;
            int shots = 0;
            int players = 0;
            foreach (var kv in events)
            {
                evt = kv.Value;
                result += evt.NewShots * (players + evt.NewPlayers) + shots * evt.NewPlayers;
                shots += evt.NewShots - evt.LeaveShots;
                players += evt.NewPlayers- evt.LeavePlayers;
            }

            return result;
        }

        private class QueueEvent
        {
            public int NewPlayers { get; set; }
            public int NewShots { get; set; }
            public int LeavePlayers { get; set; }
            public int LeaveShots { get; set; }
        }
    }
}
