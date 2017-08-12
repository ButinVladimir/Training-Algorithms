using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_16;

public class Solution
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

        public ulong NextULong()
        {
            return this.NextToken(ulong.Parse);
        }

        public double NextDouble()
        {
            return this.NextToken(double.Parse);
        }

        public decimal NextDecimal()
        {
            return this.NextToken(decimal.Parse);
        }

        public char NextChar()
        {
            return this.NextToken(char.Parse);
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

    public static void Main()
    {
        //StreamReader reader = new StreamReader(File.OpenRead("input.txt"));
        //Console.SetIn(reader);

        //StreamWriter writer = File.CreateText("output.txt");
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        int k = tokenizer.NextInt();

        SetEnumeration se = new SetEnumeration() { N = n, K = k };
        Console.WriteLine(string.Join("\n", se.Solve()));

        //writer.Close();
    }

    public class SetEnumeration
    {
        public int N { get; set; }
        public int K { get; set; }
        private LinkedList<int>[] buffer;
        private List<string> result;
        private bool[] visited;

        public List<string> Solve()
        {
            this.buffer = new LinkedList<int>[this.K];
            this.result = new List<string>();
            this.visited = new bool[this.N];

            for (int i = 0; i < this.K; i++)
            {
                this.buffer[i] = new LinkedList<int>();
            }
            this.Step(0, 0, true, this.N);

            return this.result;
        }

        private void Step(int n, int k, bool first, int left)
        {
            if (k == this.K)
            {
                if (left > 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var group in this.buffer)
                {
                    sb
                        .Append('[')
                        .Append(string.Join(",", group))
                        .Append(']');
                }

                this.result.Add(sb.ToString());

                return;
            }

            if (k != this.K - 1 && left == 0)
            {
                return;
            }

            if (n < this.N && this.visited[n])
            {
                this.Step(n + 1, k, first, left);

                return;
            }

            if (n >= this.N)
            {
                return;
            }

            this.buffer[k].AddLast(n + 1);
            this.visited[n] = true;

            this.Step(0, k + 1, true, left - 1);
            this.Step(n + 1, k, false, left - 1);

            this.buffer[k].RemoveLast();
            this.visited[n] = false;

            if (!first)
            {
                this.Step(n + 1, k, false, left);
            }
        }
    }
}