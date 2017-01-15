using System;
using Algorithms.Set_55;
using System.Collections.Generic;

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
        Driver driver = new Driver()
        {
            N = 3,
            Start = 0,
            Finish = 2,
            Cu = 4,
            Lu = 5,
            Roads = new List<Driver.Road>()
            {
                new Driver.Road()
                {
                    From = 0,
                    To = 1,
                    Cost = 1,
                    Length = 3
                },
                new Driver.Road()
                {
                    From = 1,
                    To = 2,
                    Cost = 4,
                    Length = 2
                },
                new Driver.Road()
                {
                    From = 0,
                    To = 2,
                    Cost = 4,
                    Length = 1
                },
                new Driver.Road()
                {
                    From = 0,
                    To = 2,
                    Cost = 2,
                    Length = 11
                },
            }
        };

        Driver.Path result = driver.Solve();
        if (result == null)
        {
            Console.WriteLine("Nothing");
        }
        else
        {
            Console.WriteLine("C = {0}", result.C);
            Console.WriteLine("L = {0}", result.L);
            Console.WriteLine("Path: ");
            foreach(int vertex in result.Roads)
            {
                Console.WriteLine(" {0} ", vertex);
            }
        }
    }
}