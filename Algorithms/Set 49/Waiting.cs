using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_49
{
    class Waiting
    {
        private Tuple<long, long>[] customers;

        public int N { get; private set; }

        public Waiting(int n, long[] t, long[] l)
        {
            this.N = n;
            customers = new Tuple<long, long>[this.N];

            for (int i = 0; i < this.N; i++)
            {
                this.customers[i] = new Tuple<long, long>(t[i], l[i]);
            }

            Array.Sort(this.customers);
        }

        public long Solve()
        {
            Heap heap = new Heap(this.N);

            long result = 0;
            long currentMoment = 0;
            long interval;
            int currentCustomer = 0;

            while (currentCustomer < this.N || heap.Position > 0)
            {
                while (currentCustomer < this.N && this.customers[currentCustomer].Item1 <= currentMoment)
                {
                    result -= this.customers[currentCustomer].Item1;
                    heap.Push(this.customers[currentCustomer].Item2);
                    currentCustomer++;
                }

                if (heap.Position == 0)
                {
                    if (currentCustomer < this.N && this.customers[currentCustomer].Item1 > currentMoment)
                    {
                        currentMoment = this.customers[currentCustomer].Item1;
                    }

                    continue;
                }

                interval = heap.GetHead();
                heap.Pop();
                currentMoment += interval;
                result += currentMoment;
            }

            return result / this.N;
        }

        private class Heap
        {
            private long[] heap;

            public int Position { get; private set; }
            public int Size { get; private set; }

            public Heap(int size)
            {
                this.Size = size + 1;
                this.Position = 0;
                heap = new long[this.Size];
            }

            public long GetHead()
            {
                return heap[1];
            }

            public void Push(long value)
            {
                this.heap[++this.Position] = value;

                int position = this.Position;
                int nextPosition;
                while (position > 1)
                {
                    nextPosition = position / 2;

                    if (this.heap[nextPosition] > this.heap[position])
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
                Swap(1, this.Position--);

                int currentPosition = 1;
                int nextPosition;

                while (currentPosition < this.Position)
                {
                    nextPosition = currentPosition;

                    if (currentPosition * 2 <= this.Position && this.heap[nextPosition] > this.heap[currentPosition * 2])
                    {
                        nextPosition = currentPosition * 2;
                    }

                    if (currentPosition * 2 + 1 <= this.Position && this.heap[nextPosition] > this.heap[currentPosition * 2 + 1])
                    {
                        nextPosition = currentPosition * 2 + 1;
                    }

                    if (nextPosition != currentPosition)
                    {
                        this.Swap(nextPosition, currentPosition);
                        currentPosition = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int a, int b)
            {
                long c = this.heap[a];
                this.heap[a] = this.heap[b];
                this.heap[b] = c;
            }
        }
    }
}
