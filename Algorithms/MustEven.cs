using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustEven
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
        }
    }

    class MustEven
    {
        public static void DeleteEven(ListNode first)
        {
            ListNode prev, current, next;
            bool even = false;

            for (prev = null, current = first, next = current.Next; current != null; prev = current, current = next, next = current != null ? current.Next : null, even = !even)
            {
                if (even)
                {
                    current = prev;
                    current.Next = next;
                }
            }
        }
    }
}

/*
 * 
 * Usage
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

            Console.WriteLine("-----------------------------------------------------");

            MustEven.MustEven.DeleteEven(list);

            for (ListNode current = list; current != null; current = current.Next)
            {
                Console.WriteLine(current.Value);
            }
        }
 */
