using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MustLoop
{
    class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public bool Flagged { get; set; }

        public ListNode(int value, ListNode next = null)
        {
            this.Value = value;
            this.Next = next;
            this.Flagged = false;
        }
    }

    class MustLoop
    {
        public static bool CheckLoop(ListNode first)
        {
            ListNode current;
            for (current = first; current != null && current.Flagged == false; current = current.Next)
            {
                current.Flagged = true;
            }

            if (current == null)
            {
                return false;
            }

            return true;
        }

        public static void ClearList(ListNode first)
        {
            for (ListNode current = first; current != null && current.Flagged == true; current.Flagged = false, current = current.Next) ;
        }
    }
}

/*
 *
 * Usage
 * 
        static void Main(string[] args)
        {

            ListNode badNode = new ListNode(6);
            ListNode first = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, badNode)))));
            badNode.Next = first;
            ListNode start = new ListNode(10, new ListNode(11, new ListNode(12, first)));

            bool result = MustLoop.MustLoop.CheckLoop(start);

            Console.WriteLine(result);
        }
 */
