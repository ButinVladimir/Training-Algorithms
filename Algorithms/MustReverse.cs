using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustReverse
{
    class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }
    }

    class MustReverse
    {
        public static void reverse(ref ListNode first)
        {
            if (first == null)
            {
                return;
            }

            ListNode resultFirst = null, current = first, next;

            while (current != null)
            {
                next = current.Next;
                current.Next = resultFirst;
                resultFirst = current;
                current = next;
            }

            first = resultFirst;
        }
    }
}


/*
 *     How to use
 *         
 *         
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

    *
    */
