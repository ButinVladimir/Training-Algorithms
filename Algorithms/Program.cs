using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

//using Algorithms.Set_68;

class Solution
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

    static void Main()
    {
        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
        //StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        //Console.SetOut(writer);

        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextInt();
        string[] numbers = new string[n];

        for (int i=0;i<n;i++)
        {
            numbers[i] = tokenizer.NextToken();
        }

        BigSorting.Sort(numbers);

        for (int i=0;i<n;i++)
        {
            Console.WriteLine(numbers[i]);
        }

        //writer.Close();
    }

    public class BigSorting
    {
        public static void Sort(string[] numbers)
        {
            Comparer comparer = new Comparer();
            Array.Sort(numbers, comparer);
        }

        private class Comparer : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                if (x.Length < y.Length)
                {
                    return -1;
                }

                if (x.Length > y.Length)
                {
                    return 1;
                }

                return x.CompareTo(y);
            }
        }
    }
}