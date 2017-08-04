﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_15;

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
        int m = tokenizer.NextInt();
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
        }

        IntervalGCD igcd = new IntervalGCD(a);

        int left, right;

        for (int i = 0; i < m; i++)
        {
            left = tokenizer.NextInt() - 1;
            right = tokenizer.NextInt() - 1;

            Console.WriteLine(igcd.Query(left, right));
        }

        //writer.Close();
    }

    public class IntervalGCD
    {
        private int blocksN;
        private int blocksLength;
        private int[] a;
        private int[] blocks;

        public IntervalGCD(int[] a)
        {
            this.a = a;
            this.blocksLength = Sqrt(this.a.Length);
            this.blocksN = this.a.Length / blocksLength;

            if (this.a.Length % this.blocksLength > 0)
            {
                this.blocksN++;
            }

            this.blocks = new int[this.blocksN];

            int left, right;

            for (int block = 0; block < this.blocksN; block++)
            {
                left = block * this.blocksLength;
                right = Math.Min(a.Length - 1, left + this.blocksLength - 1);

                this.blocks[block] = this.a[left];
                for (int i = left; i <= right; i++)
                {
                    this.blocks[block] = Gcd(this.blocks[block], this.a[i]);
                }
            }
        }

        public int Query(int l, int r)
        {
            int left, right;
            int result = 0;

            for (int block = 0; block < this.blocksN; block++)
            {
                left = block * this.blocksLength;
                right = Math.Min(a.Length - 1, left + this.blocksLength - 1);

                if (l <= left && r >= right)
                {
                    result = Gcd(result, this.blocks[block]);
                }
                else
                {
                    left = Math.Max(left, l);
                    right = Math.Min(right, r);

                    for (int i = left; i <= right; i++)
                    {
                        result = Gcd(result, this.a[i]);
                    }
                }
            }

            return result;
        }

        private static int Sqrt(int a)
        {
            int r = 0;
            while (r * r <= a)
            {
                r++;
            }

            return r - 1;
        }

        private static int Gcd(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }
    }
}