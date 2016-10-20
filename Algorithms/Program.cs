﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MustNth;

namespace Algorithms
{
    class Program
    {
        private static ListNode LoadList()
        {
            int n = Int32.Parse(System.Console.ReadLine()), value;
            ListNode first = null, current = null, next = null;

            for (int i = 0;i<n;i++)
            {
                value = Int32.Parse(System.Console.ReadLine());
                next = new ListNode(value);

                if (current == null)
                {
                    first = current = next;
                } else
                {
                    current = current.Next = next;
                }
            }

            return first;
        }

        static void Main(string[] args)
        {
            ListNode list = Program.LoadList();
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------");


            ListNode result = MustNth.MustNth.GetNth(list, n);
            if  (result == null)
            {
                Console.WriteLine("Invalid n value");
            } else
            {
                Console.WriteLine(result.Value);
            }
        }
    }
}