using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_73;

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
        long[] h = new long[n];
        for (int i = 0; i < n; i++)
        {
            h[i] = tokenizer.NextLong();
        }

        Console.WriteLine(ChiefHopper.Solve(h));

        //writer.Close();
    }

    public static class ChiefHopper
    {
        public static long Solve(long[] h)
        {
            long current = -1;
            long step = 100000;
            long next;
            int n = h.Length;
            long energy;
            bool can;

            long max = h[0];
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, h[i]);
            }

            while (step > 0)
            {
                next = current + step;
                energy = next;
                can = true;

                for (int i = 0; i < n; i++)
                {
                    if (energy >= max)
                    {
                        break;
                    }

                    if (energy < 0)
                    {
                        can = false;

                        break;
                    }

                    if (energy >= h[i])
                    {
                        energy += energy - h[i];
                    }
                    else
                    {
                        energy -= h[i] - energy;
                    }
                }

                if (energy < 0)
                {
                    can = false;
                }

                if (!can)
                {
                    current = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return current + 1;
        }
    }
}