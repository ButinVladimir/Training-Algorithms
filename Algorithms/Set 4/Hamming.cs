using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_4
{
    public class Hamming
    {
        private const int N = 5000;
        private static readonly long[] Multipliers = new long[3] { 2, 3, 5 };
        private static readonly long[] Precalc = new long[N];

        static Hamming()
        {
            SortedSet<long> visited = new SortedSet<long>() { 1 };
            SortedQueue queue = new SortedQueue();
            queue.Push(1);

            int counted = 1;
            long next;

            for (int i = 0; i < N; i++)
            {
                Precalc[i] = queue.Pop();

                for (int j = 0; j < Multipliers.Length; j++)
                {
                    next = Precalc[i] * Multipliers[j];

                    if (!visited.Contains(next) && counted < N)
                    {
                        visited.Add(next);
                        queue.Push(next);
                        counted++;
                    }
                }
            }
        }

        public static long hamming(int n)
        {
            return Precalc[n - 1];
        }

        private class SortedQueue
        {
            private const int Capacity = 30000;
            private long[] queue = new long[Capacity];
            private int Length = 0;

            public void Push(long value)
            {
                this.Length++;
                this.queue[this.Length] = value;

                int currentPosition = this.Length;
                int nextPosition;
                while (currentPosition > 1)
                {
                    nextPosition = currentPosition / 2;

                    if (this.queue[nextPosition] > this.queue[currentPosition])
                    {
                        this.Swap(currentPosition, nextPosition);
                        currentPosition = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public long Pop()
            {
                long result = this.queue[1];
                Swap(1, this.Length);
                this.Length--;

                int currentPosition = 1;
                int nextPosition;
                while (currentPosition < this.Length)
                {
                    nextPosition = currentPosition;

                    for (int tryPosition = currentPosition * 2; tryPosition <= this.Length && tryPosition <= currentPosition * 2 + 1; tryPosition++)
                    {
                        if (this.queue[nextPosition] > this.queue[tryPosition])
                        {
                            nextPosition = tryPosition;
                        }
                    }

                    if (nextPosition == currentPosition)
                    {
                        break;
                    }
                    else
                    {
                        Swap(currentPosition, nextPosition);
                        currentPosition = nextPosition;
                    }
                }

                return result;
            }

            private void Swap(int pos1, int pos2)
            {
                long buffer = this.queue[pos1];
                this.queue[pos1] = this.queue[pos2];
                this.queue[pos2] = buffer;
            }
        }
    }
}
