using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_15;

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
        int n = tokenizer.NextInt();
        int k = tokenizer.NextInt();
        long[] a = new long[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextLong();
        }

        Console.WriteLine(AngryChildren2.Solve(k, a));

        //}
    }

    public static class AngryChildren2
    {
        public static long Solve(int k, long[] a)
        {
            Array.Sort(a);
            long[] sum = new long[a.Length];

            sum[0] = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                sum[i] = sum[i - 1] + a[i];
            }

            long accumulatedSum = 0;
            for (int i = 0; i < k; i++)
            {
                accumulatedSum += i * a[i] - GetSum(0, i - 1, sum);
            }

            long result = accumulatedSum;
            for (int i = k; i < a.Length; i++)
            {
                accumulatedSum += k * a[i] - GetSum(i - k, i - 1, sum);
                accumulatedSum -= GetSum(i - k + 1, i, sum) - k * a[i - k];

                result = Math.Min(result, accumulatedSum);
            }

            return result;
        }

        private static long GetSum(int left, int right, long[] sum)
        {
            if (right < 0)
            {
                return 0;
            }

            if (left > 0)
            {
                return sum[right] - sum[left - 1];
            }

            return sum[right];
        }
    }
}
