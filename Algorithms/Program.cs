using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

//using Algorithms.Set_52;
//using Algorithms.Set_53;

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

    class Washing
    {
        public int N { get; set; }

        public int K { get; set; }

        public long[] P { get; set; }

        public long[] D { get; set; }

        public long Solve()
        {
            long[] a = new long[this.N];
            long result = 0;

            for (int i = 0; i < this.N; i++)
            {
                a[i] = this.P[i] + this.D[i];
                result -= this.D[i];
            }

            Array.Sort(a);

            for (int i = this.N - 1; i >= 0 && i >= this.N - this.K; i--)
            {
                result += a[i];
            }

            return result < 0 ? 0 : result;
        }
    }

    public static void Main()
    {
        Tokenizer tokenizer = new Tokenizer();

        int n = tokenizer.NextToken(int.Parse);
        int k = tokenizer.NextToken(int.Parse);

        long[] p = new long[n];
        long[] d = new long[n];

        for (int i = 0; i < n; i++)
        {
            p[i] = tokenizer.NextToken(long.Parse);
            d[i] = tokenizer.NextToken(long.Parse);
        }

        Washing washing = new Washing()
            {
                N = n,
                K = k,
                P = p,
                D = d
            };

        Console.WriteLine(washing.Solve());
    }
}