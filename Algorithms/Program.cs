using System;
using System.Collections.Generic;
using System.IO;

using Algorithms.Set_44;

public class Program
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
        Visit visit = new Visit();
        Console.WriteLine(visit.GetCount());

        visit.RecordHit();
        Console.WriteLine(visit.GetCount());
        Console.WriteLine(visit.Log());

        visit.Wait(2);
        Console.WriteLine(visit.GetCount());
        Console.WriteLine(visit.Log());

        visit.RecordHit();
        Console.WriteLine(visit.Log());

        visit.RecordHit();
        Console.WriteLine(visit.Log());

        Console.WriteLine(visit.GetCount());
        Console.WriteLine(visit.Log());

        visit.Wait(600);
        Console.WriteLine(visit.GetCount());
        Console.WriteLine(visit.Log());

        visit.RecordHit();
        Console.WriteLine(visit.Log());
        Console.WriteLine(visit.GetCount());
    }
}