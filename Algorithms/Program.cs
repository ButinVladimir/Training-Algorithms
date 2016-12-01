﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
//using Algorithms.Set_60;

public class Program
{
    class COINS
    {
        private Dictionary<UInt64, UInt64> calculatedValues;

        public COINS()
        {
            calculatedValues = new Dictionary<ulong, ulong>();
        }

        public UInt64 Solve(UInt64 value)
        {
            if (value == 0)
            {
                return 0;
            }
            if (value == 1)
            {
                return 1;
            }
            if (calculatedValues.ContainsKey(value))
            {
                return calculatedValues[value];
            }

            UInt64 result = Math.Max(value, Solve(value / 2) + Solve(value / 3) + Solve(value / 4));
            calculatedValues[value] = result;

            return result;
        }
    }

    public static void Main()
    {
        COINS coins = new COINS();
        UInt64 value;
        string input;

        while ((input = Console.ReadLine()) != null)
        {
            value = Convert.ToUInt64(input.Trim());
            Console.WriteLine(coins.Solve(value));
        }
    }
}