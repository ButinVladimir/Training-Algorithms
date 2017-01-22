using System;
using System.IO;
//using Algorithms.Set_49;

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

    public static void Main()
    {
        //Console.SetIn(new StreamReader(File.Open("input.txt", FileMode.Open)));

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        long[] t = new long[n];
        long[] l = new long[n];

        for (int i = 0;i<n;i++)
        {
            t[i] = tokenizer.NextLong();
            l[i] = tokenizer.NextLong();
        }

        Waiting waiting = new Waiting(n, t, l);
        Console.WriteLine(waiting.Solve());
    }
}