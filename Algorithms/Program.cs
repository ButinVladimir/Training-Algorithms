using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_5;

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

        int tests = tokenizer.NextInt();
        for (int test = 0; test < tests; test++)
        {
            int n = tokenizer.NextInt();
            int[] b = new int[n];

            for (int i = 0; i < n; i++)
            {
                b[i] = tokenizer.NextInt();
            }

            Console.WriteLine(SherlockCost.Solve(b));
        }

        //writer.Close();
    }

    public static class SherlockCost
    {
        public static int Solve(int[] b)
        {
            int n = b.Length;
            int[] aMin = new int[n];
            int[] aMax = new int[n];

            for (int i = n - 2; i >= 0; i--)
            {
                aMin[i] = Math.Max(aMin[i + 1], b[i + 1] - 1 + aMax[i + 1]);
                aMax[i] = Math.Max(b[i] - 1 + aMin[i + 1], Math.Abs(b[i] - b[i + 1]) + aMax[i + 1]);
            }

            return Math.Max(aMin[0], aMax[0]);
        }
    }
}