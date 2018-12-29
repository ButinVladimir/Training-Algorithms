using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_13;

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
        //using (StreamReader reader = new StreamReader(File.OpenRead("input.txt")))
        //{
        //    Console.SetIn(reader);

        //    using (StreamWriter writer = File.CreateText("output.txt"))
        //    {
        //        Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int tests = tokenizer.NextInt();
        for (int test = 0; test < tests; test++)
        {
            int n = tokenizer.NextInt();
            Console.WriteLine(RedJohnIsBack.Solve(n));
        }

        //}
        //}
    }

    public static class RedJohnIsBack
    {
        private const int M = 300000;
        private static int[] answers = new int[41];
        private static int[] count = new int[M];

        static RedJohnIsBack()
        {
            answers[0] = 1;
            for (int i = 1; i < 41; i++)
            {
                answers[i] += answers[i - 1];
                if (i >= 4)
                {
                    answers[i] += answers[i - 4];
                }
            }

            List<int> primes = new List<int>();
            bool[] visited = new bool[M];
            for (int i = 2; i < M; i++)
            {
                if (!visited[i])
                {
                    primes.Add(i);
                }

                foreach (int prime in primes)
                {
                    if (prime * i >= M)
                    {
                        break;
                    }

                    visited[prime * i] = true;
                }
            }

            for (int i = 2; i < M; i++)
            {
                count[i] = count[i - 1];
                if (!visited[i])
                {
                    count[i]++;
                }
            }
        }

        public static int Solve(int p)
        {
            return count[answers[p]];
        }
    }
}
