using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_74;

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
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }

        int p = tokenizer.NextInt();
        int q = tokenizer.NextInt();

        Console.WriteLine(SherlockMinimax.Solve(a, p, q));

        //writer.Close();
    }

    public static class SherlockMinimax
    {
        public static long Solve(int[] a, int p, int q)
        {
            int currentMin = p;
            int currentDistance = Distance(a, p, p, q);

            Update(a, q, p, q, ref currentMin, ref currentDistance);

            Array.Sort(a);

            for (int i = 0; i < a.Length - 1; i++)
            {
                int m = (a[i] + a[i + 1]) / 2;

                for (int j = -2; j <= 2; j++)
                {
                    Update(a, m + j, p, q, ref currentMin, ref currentDistance);
                }
            }

            return currentMin;
        }

        private static void Update(int[] a, int v, int p, int q, ref int currentMin, ref int currentDistance)
        {
            int distance = Distance(a, v, p, q);
            if (distance == -1)
            {
                return;
            }

            if (distance > currentDistance || distance == currentDistance && v < currentMin)
            {
                currentMin = v;
                currentDistance = distance;
            }
        }

        private static int Distance(int[] a, int v, int p, int q)
        {
            if (v < p || v > q)
            {
                return -1;
            }

            int distance = Math.Abs(a[0] - v);
            for (int i = 0; i < a.Length; i++)
            {
                distance = Math.Min(Math.Abs(a[i] - v), distance);
            }

            return distance;
        }
    }
}