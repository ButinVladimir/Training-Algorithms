using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
//using Microsoft.VisualBasic.FileIO;
//using Algorithms.Set_28;

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

        public double NextDouble()
        {
            return this.NextToken(double.Parse);
        }

        public decimal NextDecimal()
        {
            return this.NextToken(decimal.Parse);
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

        Tokenizer tokenizer = new Tokenizer();
        int n = tokenizer.NextInt();
        int[] a = new int[n];
        int[] b = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = tokenizer.NextInt();
            b[i] = tokenizer.NextInt();
        }

        Console.WriteLine(Reaction.Solve(n, a, b));
    }

    public static class Reaction
    {
        public static int Solve(int n, int[] a, int[] b)
        {
            Beacon[] beacons = new Beacon[n];

            for (int i = 0; i < n; i++)
            {
                beacons[i] = new Beacon() { Position = a[i], Power = b[i] };
            }

            Array.Sort(beacons);
            int[] used = new int[n];
            int next;

            for (int i = 0; i < n; i++)
            {
                used[i] = 0;

                if (i > 0)
                {
                    next = FindNextSuitableBeacon(beacons[i].Position - beacons[i].Power - 1, beacons);
                    if (next >= 0)
                    {
                        used[i] = used[next] + (i - next - 1);
                    }
                    else
                    {
                        used[i] = i;
                    }
                }
            }

            int result = n;
            for (int i = 0; i < n; i++)
            {
                result = Math.Min(result, n - i - 1 + used[i]);
            }

            return result;
        }

        private static int FindNextSuitableBeacon(int maxPosition, Beacon[] beacons)
        {
            int step = beacons.Length + 1;
            int position = -1;
            int next;

            while (step > 0)
            {
                next = position + step;
                if (next >= 0 && next < beacons.Length && beacons[next].Position <= maxPosition)
                {
                    position = next;
                }
                else
                {
                    step /= 2;
                }
            }

            return position;
        }

        private class Beacon : IComparable<Beacon>
        {
            public int Position { get; set; }
            public int Power { get; set; }

            int IComparable<Beacon>.CompareTo(Beacon other)
            {
                return Position.CompareTo(other.Position);
            }
        }
    }
}