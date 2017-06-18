using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_71;

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

        int t = tokenizer.NextInt();

        for (int test = 0; test < t; test++)
        {
            int n = tokenizer.NextInt();
            string[] s = new string[n];
            for (int i = 0; i < n; i++)
            {
                s[i] = tokenizer.NextToken();
            }

            Console.WriteLine(GridChallenge.Solve(n, s) ? "YES" : "NO");
        }

        //writer.Close();
    }

    public static class GridChallenge
    {
        public static bool Solve(int n, string[] s)
        {
            char[][] letters = new char[n][];
            for (int i = 0; i < n; i++)
            {
                letters[i] = s[i].ToCharArray();
            }

            for (int i = 0; i < n; i++)
            {
                Array.Sort(letters[i]);
            }

            bool valid = true;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    valid = valid && letters[i][j] <= letters[i][j + 1] && letters[i][j] <= letters[i + 1][j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                valid = valid && letters[n - 1][i] <= letters[n - 1][i + 1] && letters[i][n - 1] <= letters[i + 1][n - 1];
            }

            return valid;
        }
    }
}