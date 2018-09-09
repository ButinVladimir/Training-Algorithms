using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustNth
{
    class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
        }
    }

    class MustNth
    {
        public static ListNode GetNth(ListNode first, int n)
        {
            if (n < 1)
            {
                return null;
            }

            ListNode current = first, nth = null;
            for (int i = 0; i < n - 1 && current != null; i++, current = current.Next) ;

            if (current == null)
            {
                //throw new IndexOutOfRangeException("List contains less than n elements"); // Wtf mate?
                return null;
            }

            nth = first;

            while (current != null)
            {
                current = current.Next;
                if (current != null)
                {
                    nth = nth.Next;
                }
            }

            return nth;
        }
    }
}


/*
 * 
 * Usage
 * 
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
 */
