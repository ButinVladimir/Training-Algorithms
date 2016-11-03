using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    using Set_47;

    class Program
    {
        static void PrintList(LinkedList <int> list)
        {
            foreach (int value in list)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Factorizations factorizations = new Factorizations();

            int n = Convert.ToInt32(Console.ReadLine());
            LinkedList <LinkedList <int> > result = factorizations.Solve(n);

            foreach (LinkedList<int> list in result)
            {
                PrintList(list);
            }
        }
    }
}