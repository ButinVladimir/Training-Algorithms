﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_3;

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
        int k = tokenizer.NextInt();
        int[] l = new int[n];
        int[] t = new int[n];

        for (int i = 0; i < n; i++)
        {
            l[i] = tokenizer.NextInt();
            t[i] = tokenizer.NextInt();
        }

        Console.WriteLine(LuckBalance.Solve(n, k, l, t));

        //writer.Close();
    }

    public static class LuckBalance
    {
        public static int Solve(int n, int k, int[] l, int[] t)
        {
            int result = 0;

            List<int> mandatoryList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (t[i] == 0)
                {
                    result += l[i];
                }
                else
                {
                    mandatoryList.Add(l[i]);
                }
            }

            int[] mandatoryArray = mandatoryList.ToArray();
            Array.Sort(mandatoryArray);
            for (int i = mandatoryArray.Length - 1; i >= 0; i--)
            {
                if (k > 0)
                {
                    result += mandatoryArray[i];
                    k--;
                }
                else
                {
                    result -= mandatoryArray[i];
                }
            }

            return result;
        }
    }
}