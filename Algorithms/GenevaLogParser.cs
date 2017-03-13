//using System;
//using System.Numerics;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;
//using Algorithms.Set_34;

//using Microsoft.VisualBasic.FileIO;

//class Solution
//{
//    private class Tokenizer
//    {
//        private string currentString = null;

//        private string[] tokens = null;

//        private int tokenNumber = 0;

//        private static readonly char[] Separators = { ' ' };

//        public T NextToken<T>(Func<string, T> parser)
//        {
//            return parser(this.GetNextToken());
//        }

//        public string NextToken()
//        {
//            return this.GetNextToken();
//        }

//        public int NextInt()
//        {
//            return this.NextToken(int.Parse);
//        }

//        public long NextLong()
//        {
//            return this.NextToken(long.Parse);
//        }

//        private string GetNextToken()
//        {
//            if (this.currentString == null || this.tokenNumber == this.tokens.Length)
//            {
//                this.currentString = this.GetNextString();

//                while (this.currentString != null && this.currentString.Equals(string.Empty))
//                {
//                    this.currentString = this.GetNextString();
//                }

//                if (this.currentString == null)
//                {
//                    throw new Exception("End of input");
//                }

//                this.tokens = this.currentString.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
//                this.tokenNumber = 0;
//            }

//            return this.tokens[this.tokenNumber++];
//        }

//        private string GetNextString()
//        {
//            string content = Console.ReadLine();
//            if (content == null)
//            {
//                return null;
//            }

//            return content.Trim();
//        }
//    }

//    static void Main()
//    {
//        //Console.SetIn(new StreamReader(File.OpenRead("input.txt")));
//        StreamWriter writer = new StreamWriter(File.Create("output.txt"));
//        Console.SetOut(writer);

//        SortedSet<string> oldMachines = new SortedSet<string>();
//        SortedSet<string> newMachines = new SortedSet<string>();
//        StringBuilder sb = new StringBuilder();

//        using (TextFieldParser parser = new TextFieldParser(@"logs_old.csv"))
//        {
//            parser.TextFieldType = FieldType.Delimited;
//            parser.SetDelimiters(",");

//            while (!parser.EndOfData)
//            {
//                string[] tokens = parser.ReadFields();
//                string entity = MakeEntity(tokens, sb);

//                oldMachines.Add(entity);
//            }
//        }

//        using (TextFieldParser parser = new TextFieldParser(@"logs_new.csv"))
//        {
//            parser.TextFieldType = FieldType.Delimited;
//            parser.SetDelimiters(",");

//            while (!parser.EndOfData)
//            {
//                string[] tokens = parser.ReadFields();
//                string entity = MakeEntity(tokens, sb);

//                newMachines.Add(entity);
//            }
//        }

//        Console.WriteLine("Those machines don't have old cert:");
//        foreach (var machine in newMachines)
//        {
//            if (!oldMachines.Contains(machine))
//            {
//                Console.WriteLine(machine);
//            }
//        }

//        Console.WriteLine("Certificate wasn't installed on:");
//        foreach (var machine in oldMachines)
//        {
//            if (!newMachines.Contains(machine))
//            {
//                Console.WriteLine(machine);
//            }
//        }

//        writer.Close();
//    }

//    private static string MakeEntity(string[] tokens, StringBuilder sb)
//    {
//        sb.Clear();
//        sb.Append(tokens[4]);

//        return sb.ToString();
//    }
//}