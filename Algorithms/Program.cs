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
    }
}
