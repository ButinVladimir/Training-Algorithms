using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Algorithms.Set_63;

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

    public static void Test(int[] items)
    {
        int result = LazyLoading.Solve(items);
        int resultStress = LazyLoading.StressSolve(items);
        Console.WriteLine(
            "Result = {0}, Stress test result = {1}, Status = {2}",
            result, 
            resultStress, 
            result == resultStress ? "OK" : "WA");
    }

    public static void Main()
    {
        Test(new int[] { 45, 46, 57, 1, 2, 3, 9, 100, 45, 46, 57, 1, 2, 3, 9, 100 });
        Test(new int[] { 30, 30, 1, 1 });
        Test(new int[] { 20, 20, 20 });
        Test(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        Test(new int[] { 9, 19, 29, 39, 49, 59 });
        //Test(new int[] { 32, 56, 76, 8, 44, 60, 47, 85, 71, 91 });
    }
}