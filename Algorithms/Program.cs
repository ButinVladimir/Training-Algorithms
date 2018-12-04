using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_11;

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
        // Console.SetIn(reader);

        //    using (StreamWriter writer = File.CreateText("output.txt"))
        //    {
        //        Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();
        int year = tokenizer.NextInt();

        Console.WriteLine(DayOfTheProgrammer.Solve(year));
        //    }
        //}
    }

    public static class DayOfTheProgrammer
    {
        public static string Solve(int year)
        {
            if (year == 1918)
            {
                return "26.09." + year;
            }

            if (year < 1918 && year % 4 == 0)
            {
                return "12.09." + year;
            }

            if (year >= 1918 && (year % 400 == 0) || (year % 100 != 0 && year % 4 == 0))
            {
                return "12.09." + year;
            }

            return "13.09." + year;
        }
    }
}
