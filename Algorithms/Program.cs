using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//using Algorithms.Fun_2;

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
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int t = tokenizer.NextInt();
        for (int test = 0; test < t; test++)
        {
            int n = tokenizer.NextInt();
            int k = tokenizer.NextInt();

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = tokenizer.NextInt();
            }

            Console.WriteLine(Professor.Solve(n, k, a) ? "YES" : "NO");
        }

        //writer.Close();
    }

    public class Professor
    {
        public static bool Solve(int n, int k, int[] a)
        {
            for (int i = 0; i < n; i++)
            {
                if (a[i] <= 0)
                {
                    k--;
                }
            }

            return k > 0;
        }
    }
}