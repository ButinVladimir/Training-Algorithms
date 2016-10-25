using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 9, 5, 3, 3, 5, 5, 4, 1, 2, 8, 10 };

            System.Console.WriteLine(Fun.Pond.Pond.MaxDepth(a));
            System.Console.WriteLine(Fun.Pond.Pond.Volume(a));
        }
    }
}