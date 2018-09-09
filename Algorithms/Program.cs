using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_10;

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
        //  Console.SetIn(reader);

        //StreamWriter writer = File.CreateText("output.txt");
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        long[] a = new long[5];
        for (int i = 0; i < 5; i++)
        {
            a[i] = tokenizer.NextLong();
        }

        Tuple<long, long> result = MiniMaxSum.Solve(a);
        Console.WriteLine($"{result.Item1} {result.Item2}");

        //writer.Close();
        //}
        //}
    }

    public static class BirthdayCakeCandles
    {
        public static int Solve(int[] a)
        {
            int max = a.Max();
            return a.Count(v => v == max);
        }
    }

    public static class MiniMaxSum
    {
        public static Tuple<long, long> Solve(long[] a)
        {
            long sum = a.Sum();
            long min = sum - a[0];
            long max = sum - a[0];
            long buf;

            for (int i = 0; i < a.Length; i++)
            {
                buf = sum - a[i];
                min = Math.Min(min, buf);
                max = Math.Max(max, buf);
            }

            return new Tuple<long, long>(min, max);
        }
    }
}
