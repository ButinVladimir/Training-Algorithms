using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Fun_9;

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

        int n = tokenizer.NextInt();
        string s = tokenizer.NextToken();
        Console.WriteLine(TwoCharacters.Solve(s));

        //writer.Close();
        //}
        //}
    }

    public static class TwoCharacters
    {
        public static int Solve(string s)
        {
            int result = 0;

            for (char c1 = 'a'; c1 <= 'z'; c1++)
            {
                for (char c2 = 'a'; c2 <= 'z'; c2++)
                {
                    if (c1 != c2)
                    {
                        result = Math.Max(result, SolveInternal(s, c1, c2));
                    }
                }
            }

            return result;
        }

        private static int SolveInternal(string s, char c1, char c2)
        {
            int p = 0;
            while (p < s.Length && s[p] != c1)
            {
                if (s[p] == c2)
                {
                    return 0;
                }
                p++;
            }
            if (p == s.Length)
            {
                return 0;
            }
            p++;

            int result = 1;
            bool second = true;
            while (p < s.Length)
            {
                if (second)
                {
                    if (s[p] == c2)
                    {
                        second = false;
                        result++;
                    }
                    else if (s[p] == c1)
                    {
                        return 0;
                    }
                }
                else
                {
                    if (s[p] == c1)
                    {
                        second = true;
                        result++;
                    }
                    else if (s[p] == c2)
                    {
                        return 0;
                    }
                }

                p++;
            }

            return result > 1 ? result : 0;
        }
    }
}
