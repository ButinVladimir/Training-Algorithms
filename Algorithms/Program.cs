using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_4;

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

        int s = tokenizer.NextInt();
        int n = tokenizer.NextInt();
        int m = tokenizer.NextInt();

        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }

        int[] b = new int[m];
        for (int i = 0; i < m; i++)
        {
            b[i] = tokenizer.NextInt();
        }

        Console.WriteLine(ElectronicsShop.Solve(s, a, b));

        //writer.Close();
    }

    public static class ElectronicsShop
    {
        public static int Solve(int s, int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(b);

            int posB = 0;
            int result = -1;

            for (int i = 0; i < a.Length; i++)
            {
                while (posB < b.Length && a[i] + b[posB] > s)
                {
                    posB++;
                }

                if (posB < b.Length)
                {
                    result = Math.Max(result, a[i] + b[posB]);
                }
            }

            return result;
        }
    }
}