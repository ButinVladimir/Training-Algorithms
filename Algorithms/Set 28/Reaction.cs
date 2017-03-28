using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public static class Reaction
    {
        public static int Solve(int n, int[] a, int[] b)
        {
            Beacon[] beacons = new Beacon[n];

            for (int i = 0; i < n; i++)
            {
                beacons[i] = new Beacon() { Position = a[i], Power = b[i] };
            }

            Array.Sort(beacons);
            int[] used = new int[n];
            int next;

            for (int i = 0; i < n; i++)
            {
                used[i] = 0;

                if (i > 0)
                {
                    next = FindNextSuitableBeacon(beacons[i].Position - beacons[i].Power - 1, beacons);
                    if (next >= 0)
                    {
                        used[i] = used[next] + (i - next - 1);
                    }
                    else
                    {
                        used[i] = i;
                    }
                }
            }

            int result = n;
            for (int i = 0; i < n; i++)
            {
                result = Math.Min(result, n - i - 1 + used[i]);
            }

            return result;
        }

        private static int FindNextSuitableBeacon(int maxPosition, Beacon[] beacons)
        {
            int step = beacons.Length + 1;
            int position = -1;
            int next;

            while (step > 0)
            {
                next = position + step;
                if (next >= 0 && next < beacons.Length && beacons[next].Position <= maxPosition)
                {
                    position = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return position;
        }

        private class Beacon : IComparable<Beacon>
        {
            public int Position { get; set; }
            public int Power { get; set; }

            int IComparable<Beacon>.CompareTo(Beacon other)
            {
                return Position.CompareTo(other.Position);
            }
        }
    }
}
