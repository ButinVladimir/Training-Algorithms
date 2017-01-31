using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//using Algorithms.Set_65;

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

    public static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);
        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        long[] a = new long[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextLong();
        }

        Console.WriteLine("{0}", Rectangle.Solve(a));

        //writer.Close();
    }

    class Rectangle
    {
        public static long Solve(long[] heights)
        {
            long[] prev = BuildLeft(heights);
            long[] next = BuildRight(heights);

            long result = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                result = Math.Max(result, heights[i] * (next[i] - prev[i] - 1));
            }

            return result;
        }

        private static long[] BuildLeft(long[] heights)
        {
            int n = heights.Length;

            long[] prev = new long[n];

            long nextPrev;

            for (int i = 0; i < n; i++)
            {
                nextPrev = i - 1;
                while (nextPrev >= 0 && heights[i] <= heights[nextPrev])
                {
                    nextPrev = prev[nextPrev];
                }

                prev[i] = nextPrev;
            }

            return prev;
        }

        private static long[] BuildRight(long[] heights)
        {
            int n = heights.Length;

            long[] next = new long[n];

            long nextNext;

            for (int i = n - 1; i >= 0; i--)
            {
                nextNext = i + 1;
                while (nextNext < n && heights[i] <= heights[nextNext])
                {
                    nextNext = next[nextNext];
                }

                next[i] = nextNext;
            }

            return next;
        }
    }
}