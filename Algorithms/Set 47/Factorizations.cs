using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_47
{
    class Factorizations
    {
        private LinkedList<int> currentDivisors;
        private LinkedList<LinkedList<int>> result;

        private void AddToResult()
        {
            LinkedList<int> buffer = new LinkedList<int>();

            foreach (int value in this.currentDivisors)
            {
                buffer.AddLast(value);
            }

            result.AddLast(buffer);
        }

        private void ProcessNumber(int number, int minDivisor = 2)
        {
            if (number == 1)
            {
                this.AddToResult();
            }

            for (int divisor = minDivisor; divisor <= number && divisor * divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                {
                    currentDivisors.AddLast(divisor);
                    this.ProcessNumber(number / divisor, divisor);
                    currentDivisors.RemoveLast();
                }
            }

            if (number >= minDivisor)
            {
                currentDivisors.AddLast(number);
                this.ProcessNumber(1, number);
                currentDivisors.RemoveLast();
            }
        }

        public LinkedList<LinkedList<int>> Solve(int number)
        {
            this.result = new LinkedList<LinkedList<int>>();
            this.currentDivisors = new LinkedList<int>();

            this.ProcessNumber(number);

            return result;
        }
    }
}


/*
 * 
 * Usage
 
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

 */
