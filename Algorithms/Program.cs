using System;
using System.Collections.Generic;
using System.IO;

//using Algorithms.Fun;

public class Program
{
    private class Tokenizer
    {
        private string currentString = null;

        private string[] tokens = null;

        private int tokenNumber = 0;

        private static readonly char[] Separators = { ' ' };

        public T NextToken<T>(Func<string, T> parser)
        {
            return parser(this.GetNextToken());
        }

        public string NextToken()
        {
            return this.GetNextToken();
        }

        public int NextInt()
        {
            return this.NextToken(int.Parse);
        }

        public long NextLong()
        {
            return this.NextToken(long.Parse);
        }

        private string GetNextToken()
        {
            if (this.currentString == null || this.tokenNumber == this.tokens.Length)
            {
                this.currentString = this.GetNextString();

                while (this.currentString != null && this.currentString.Equals(string.Empty))
                {
                    this.currentString = this.GetNextString();
                }

                if (this.currentString == null)
                {
                    throw new Exception("End of input");
                }

                this.tokens = this.currentString.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                this.tokenNumber = 0;
            }

            return this.tokens[this.tokenNumber++];
        }

        private string GetNextString()
        {
            string content = Console.ReadLine();
            if (content == null)
            {
                return null;
            }

            return content.Trim();
        }
    }

    class Merging
    {
        private int[] leader;
        private int[] size;

        public Merging(int n)
        {
            this.leader = new int[n];
            this.size = new int[n];

            for (int i = 0; i < n; i++)
            {
                this.leader[i] = i;
                this.size[i] = 1;
            }
        }

        public int Get(int pos)
        {
            return this.size[this.GetLeader(pos)];
        }

        public void Merge(int posA, int posB)
        {
            posA = this.GetLeader(posA);
            posB = this.GetLeader(posB);

            if (posA == posB)
            {
                return;
            }

            if (this.size[posB] < this.size[posA])
            {
                this.leader[posB] = posA;
                this.size[posA] += this.size[posB];
            }
            else
            {
                this.leader[posA] = posB;
                this.size[posB] += this.size[posA];
            }
        }

        private int GetLeader(int pos)
        {
            if (this.leader[pos] == pos)
            {
                return pos;
            }

            this.leader[pos] = this.GetLeader(this.leader[pos]);
            return this.leader[pos];
        }
    }

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
            }
            else
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

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        RunningMedian median = new RunningMedian(n);

        for (int i = 0;i<n;i++)
        {
            Console.WriteLine(median.Add(tokenizer.NextInt()));
        }
    }
}