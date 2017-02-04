using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

//using Algorithms.Set_66;

class Solution
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

    static void Main()
    {
        Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        long[] petrol = new long[n];
        long[] distance = new long[n];

        for (int i = 0; i < n; i++)
        {
            petrol[i] = tokenizer.NextLong();
            distance[i] = tokenizer.NextLong();
        }

        Truck truck = new Truck()
        {
            N = n,
            Petrol = petrol,
            Distance = distance
        };

        Console.WriteLine(truck.Solve());

        //writer.Close();
    }

    public class Truck
    {
        private State[] states;
        private long[] left;
        private int[] nextPoint;

        public int N { get; set; }

        public long[] Petrol { get; set; }

        public long[] Distance { get; set; }

        public int Solve()
        {
            this.states = new State[this.N];
            this.left = new long[this.N];
            this.nextPoint = new int[this.N];

            for (int i = 0; i < this.N; i++)
            {
                this.states[i] = State.NotVisited;
                this.nextPoint[i] = i;
                this.left[i] = this.Petrol[i];
            }

            for (int i = 0; i < this.N; i++)
            {
                if (this.Travel(i))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool Travel(int start)
        {
            if (this.states[start] == State.Visited)
            {
                return false;
            }

            Stack<int> positions = new Stack<int>();
            positions.Push(start);

            this.states[start] = State.Processing;

            int current, next;
            int prev;

            while (positions.Count > 0)
            {
                current = positions.Peek();
                next = this.nextPoint[current];

                if (this.Distance[next] > this.left[current])
                {
                    this.states[current] = State.Visited;
                    positions.Pop();

                    if (positions.Count > 0)
                    {
                        prev = positions.Peek();
                        this.nextPoint[prev] = this.nextPoint[current];
                        this.left[prev] += this.left[current];
                    }
                }
                else
                {
                    this.left[current] -= this.Distance[next];
                    this.nextPoint[current] = next = (next + 1) % this.N;

                    if (this.states[next] == State.Processing)
                    {
                        return true;
                    }

                    if (this.states[next] == State.Visited)
                    {
                        this.left[current] += this.left[next];
                        this.nextPoint[current] = this.nextPoint[next];
                    }
                    else
                    {
                        positions.Push(next);
                        this.states[next] = State.Processing;
                    }
                }
            }

            return false;
        }

        private enum State
        {
            NotVisited,
            Processing,
            Visited
        }
    }
}