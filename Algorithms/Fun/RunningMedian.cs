using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class RunningMedian
    {
        private int counter;
        private Heap maxHeap;
        private Heap minHeap;

        public RunningMedian(int n)
        {
            this.maxHeap = new Heap(n, (a, b) => a > b);
            this.minHeap = new Heap(n, (a, b) => a < b);
            this.counter = 0;
        }

        public string Add(int value)
        {
            this.counter++;

            if (this.counter % 2 == 1)
            {
                this.minHeap.Add(value);
                this.maxHeap.Add(this.minHeap.Get());
                this.minHeap.Pop();

                return string.Format("{0}.0", this.maxHeap.Get());
            } else
            {
                this.maxHeap.Add(value);
                this.minHeap.Add(this.maxHeap.Get());
                this.maxHeap.Pop();

                int result = this.minHeap.Get() + this.maxHeap.Get();
                int mod = result % 2 == 1 ? 5 : 0;

                return string.Format("{0}.{1}", result / 2, mod);
            }
        }

        private class Heap
        {
            private int[] heap;
            private Func<int, int, bool> comparer;
            private int counter;

            public Heap(int size, Func<int, int, bool> comparer)
            {
                this.heap = new int[size + 1];
                this.counter = 0;
                this.comparer = comparer;
            }

            public int Get()
            {
                return this.heap[1];
            }

            public void Add(int value)
            {
                this.heap[++this.counter] = value;

                int position = this.counter;
                int nextPosition;

                while (position > 1)
                {
                    nextPosition = position / 2;
                    if (this.comparer(this.heap[position], this.heap[nextPosition]))
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
                this.Swap(1, this.counter--);

                int position = 1;
                int nextPosition;

                while (position < this.counter)
                {
                    nextPosition = position;
                    if (position * 2 <= this.counter && this.comparer(this.heap[position * 2], this.heap[nextPosition]))
                    {
                        nextPosition = position * 2;
                    }
                    if (position * 2 + 1 <= this.counter && this.comparer(this.heap[position * 2 + 1], this.heap[nextPosition]))
                    {
                        nextPosition = position * 2 + 1;
                    }

                    if (nextPosition != position)
                    {
                        this.Swap(nextPosition, position);
                        position = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int a, int b)
            {
                int buffer = this.heap[a];
                this.heap[a] = this.heap[b];
                this.heap[b] = buffer;
            }
        }
    }
}
