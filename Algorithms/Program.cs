using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Algorithms.Set_64;

public class Program
{
    private class Tokenizer
    {
        private string currentString = null;
        private string[] tokens;
        private int tokenNumber;
        private char[] separators;

        public Tokenizer()
        {
            currentString = null;
            tokens = null;
            tokenNumber = 0;
            separators = new char[] { ' ' };
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

        public string NextToken()
        {
            if (currentString == null || tokenNumber == tokens.Length)
            {
                currentString = GetNextString();
                while (currentString != null && currentString.Equals(string.Empty))
                {
                    currentString = GetNextString();
                }

                if (currentString == null)
                {
                    return null;
                }

                tokens = currentString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                tokenNumber = 0;
            }

            return tokens[tokenNumber++];
        }
    }

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();

        int t = Convert.ToInt32(tokenizer.NextToken());
        int n, m;
        long[][] costs;

        for (int test = 1; test <= t; test++)
        {
            n = Convert.ToInt32(tokenizer.NextToken());
            m = Convert.ToInt32(tokenizer.NextToken());

            costs = new long[n][];
            for (int i = 0; i < n; i++)
            {
                costs[i] = new long[m];

                for (int j = 0; j < m; j++)
                {
                    costs[i][j] = Convert.ToInt64(tokenizer.NextToken());
                }
            }

            Console.WriteLine("Case #{0}: {1}", test, Pies.Solve(n, m, costs));
        }
    }
}