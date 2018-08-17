using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustCommon
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

    class MustCommon
    {
        public static bool HaveCommon(ListNode a, ListNode b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            for (ListNode currentA = a; currentA != null; currentA = currentA.Next)
            {
                for (ListNode currentB = b; currentB != null; currentB = currentB.Next)
                {
                    if (currentA.Value == currentB.Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

/*
 * 
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
            ListNode a = Program.LoadList()
                , b = Program.LoadList();

            Console.WriteLine(MustCommon.MustCommon.HaveCommon(a, b));
        }
 */
