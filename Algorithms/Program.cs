﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MustReverse;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(System.Console.ReadLine()), value;
            ListNode first = null, current = null, next;

            for (int i = 0; i < n; i++)
            {
                value = Int32.Parse(System.Console.ReadLine());
                next = new ListNode() { Value = value };

                if (current == null)
                {
                    first = current = next;
                }
                else
                {
                    current.Next = next;
                    current = next;
                }
            }

            MustReverse.MustReverse.reverse(ref first);
            current = first;

            while (current != null)
            {
                Console.Write("{0} ", current.Value);
                current = current.Next;
            }
        }
    }
}