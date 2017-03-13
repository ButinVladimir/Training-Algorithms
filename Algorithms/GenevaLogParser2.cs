using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Algorithms.Set_34;

using Microsoft.VisualBasic.FileIO;

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
        StreamWriter writer = new StreamWriter(File.Create("output.txt"));
        Console.SetOut(writer);

        SortedDictionary<string, List<string>> machines = new SortedDictionary<string, List<string>>();
        StringBuilder sb = new StringBuilder();

        using (TextFieldParser parser = new TextFieldParser(@"logs.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] tokens = parser.ReadFields();
                string key = MakeKey(tokens, sb);
                string value = MakeValue(tokens, sb);

                if (!machines.ContainsKey(key))
                {
                    machines[key] = new List<string>();
                }

                machines[key].Add(value);
            }
        }

        foreach (var kv in machines)
        {
            Console.WriteLine("{0}:", kv.Key);
            Console.WriteLine("Machines");
            foreach (var machine in kv.Value)
            {
                Console.Write(machine);
                Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        writer.Close();
    }

    private static string MakeEntity(string[] tokens, StringBuilder sb)
    {
        sb.Clear();
        sb.Append(tokens[4]);

        return sb.ToString();
    }

    private static string MakeKey(string[] tokens, StringBuilder sb)
    {
        sb.Clear();
        sb.Append("Valid to: ");
        sb.Append(tokens[4]);

        sb.Append("\r\n");
        sb.Append("IsCurrentOnMachine: ");
        sb.Append(tokens[6]);

        sb.Append("\r\n");
        sb.Append("IsCurrentOnDms: ");
        sb.Append(tokens[8]);

        sb.Append("\r\n");
        sb.Append("Cert error: ");
        sb.Append(tokens[9]);

        sb.Append("\r\n");
        sb.Append("Cert name: ");
        sb.Append(tokens[10]);

        sb.Append("\r\n");
        sb.Append("Thumbprint: ");
        sb.Append(tokens[12]);

        sb.Append("\r\n");
        sb.Append("Subject name: ");
        sb.Append(tokens[13]);

        return sb.ToString();
    }

    private static string MakeValue(string[] tokens, StringBuilder sb)
    {
        sb.Clear();
        sb.Append(tokens[0]);

        return sb.ToString();
    }
}