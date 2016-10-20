using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MustLoop;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            ListNode badNode = new ListNode(6);
            ListNode first = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, badNode)))));
            badNode.Next = first;
            ListNode start = new ListNode(10, new ListNode(11, new ListNode(12, first)));

            bool result;
            result = MustLoop.MustLoop.CheckLoop(start);
            Console.WriteLine(result);
        }
    }
}