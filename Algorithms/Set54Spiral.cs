using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Set54Spiral
    {
        public static int[] Iterate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] result = new int[n * n];

            int finish = n / 2 + n % 2, currentElement = 0;
            for (int pos = 0; pos < finish; pos++)
            {
                for (int x = pos; x < n - pos; x++)
                {
                    result[currentElement++] = matrix[pos, x];
                }

                for (int y = pos + 1; y < n - pos; y++)
                {
                    result[currentElement++] = matrix[y, n - 1 - pos];
                }

                for (int x = n - 2 - pos; x >= pos; x--)
                {
                    result[currentElement++] = matrix[n - 1 - pos, x];
                }

                for (int y = n - 2 - pos; y > pos; y--)
                {
                    result[currentElement++] = matrix[y, pos];
                }
            }

            return result;
        }
    }
}

/*
 *     How to use
 *         
 *         
       static void Main(string[] args)
        {
            int n = Int32.Parse(System.Console.ReadLine());

            int[,] a = new int[n, n];
            for (int y = 0; y < n; y++)
            {
               String [] tokens = System.Console.ReadLine().Split(new char[] { ' ' });
               for (int x = 0; x < n; x++)
                {
                    a[y, x] = Int32.Parse(tokens[x]);
                }
            }

            int[] result = Set54Spiral.Iterate(a);
            for (int i = 0, l = n * n; i < l; i++)
            {
                System.Console.Write(result[i].ToString() + ' ');
            }
        }
    *
    */