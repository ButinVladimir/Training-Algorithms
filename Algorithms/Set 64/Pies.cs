using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_64
{
    public class Pies
    {
        public static long Solve(int n, int m, long[][] costs)
        {
            Heap heap = new Heap(n * m);

            long result = 0;

            for (int i = 0; i < n; i++)
            {
                Array.Sort(costs[i]);

                for (int j = 0; j < m; j++)
                {
                    heap.Push(costs[i][j] + (j + 1) * (j + 1) - j * j);
                }

                result += heap.Pop();
            }

            return result;
        }

        class Heap
        {
            private long[] values;

            private int currentSize = 0;

            public Heap(int size)
            {
                this.values = new long[size + 1];
            }

            public void Push(long value)
            {
                this.values[++this.currentSize] = value;
                int position = this.currentSize;
                int nextPosition;
                long buffer;

                while (position > 1)
                {
                    nextPosition = position / 2;

                    if (this.values[nextPosition] > this.values[position])
                    {
                        buffer = this.values[nextPosition];
                        this.values[nextPosition] = this.values[position];
                        this.values[position] = buffer;
                        position = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public long Pop()
            {
                if (this.currentSize == 0)
                {
                    return -1;
                }

                long result = this.values[1];
                this.values[1] = this.values[this.currentSize--];

                int position = 1;
                int nextPosition;
                long buffer;

                while (position <= this.currentSize)
                {
                    nextPosition = position;
                    if (position * 2 <= this.currentSize && this.values[position * 2] < this.values[nextPosition])
                    {
                        nextPosition = position * 2;
                    }

                    if ((position * 2 + 1) <= this.currentSize && this.values[position * 2 + 1] < this.values[nextPosition])
                    {
                        nextPosition = position * 2 + 1;
                    }

                    if (nextPosition != position)
                    {
                        buffer = this.values[position];
                        this.values[position] = this.values[nextPosition];
                        this.values[nextPosition] = buffer;
                        position = nextPosition;
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }
        }
    }
}
