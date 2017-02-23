using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_36
{
    public class Cookies
    {
        public static int Solve(long[] a, int n, long k)
        {
            Heap heap = new Heap();

            for (int i = 0; i < n; i++)
            {
                heap.Add(a[i]);
            }

            long a1, a2;
            for (int i = 0; i < n - 1; i++)
            {
                if (heap.GetMin() >= k)
                {
                    return i;
                }

                a1 = heap.GetMin();
                heap.Pop();
                a2 = heap.GetMin();
                heap.Pop();
                heap.Add(a1 + 2 * a2);
            }

            return (heap.GetMin() >= k) ? n - 1 : -1;
        }

        private class Heap
        {
            private int currentIndex = 1;
            private long[] heap = new long[1000100];

            public long GetMin()
            {
                return heap[1];
            }

            public void Add(long value)
            {
                this.heap[this.currentIndex++] = value;

                int position, nextPosition;
                position = this.currentIndex - 1;

                while (position > 1)
                {
                    nextPosition = position / 2;

                    if (this.heap[position] < this.heap[nextPosition])
                    {
                        this.Swap(position, nextPosition);
                        position = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public void Pop()
            {
                Swap(1, --this.currentIndex);

                int position = 1;
                int nextPosition, tryPosition;

                while (position < this.currentIndex)
                {
                    nextPosition = position;

                    tryPosition = position * 2;
                    if (tryPosition < this.currentIndex && this.heap[nextPosition] > this.heap[tryPosition])
                    {
                        nextPosition = tryPosition;
                    }

                    tryPosition = position * 2 + 1;
                    if (tryPosition < this.currentIndex && this.heap[nextPosition] > this.heap[tryPosition])
                    {
                        nextPosition = tryPosition;
                    }

                    if (nextPosition != position)
                    {
                        this.Swap(position, nextPosition);
                        position = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int i1, int i2)
            {
                long b = this.heap[i1];
                this.heap[i1] = this.heap[i2];
                this.heap[i2] = b;
            }
        }
    }
}
