using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    using Set_55;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberConstruction.Construct(23));
            /*
            int n = 5, startX = 0, startY = 0, targetX = 2, targetY = 2, value = 2;
            int[] numbers = new int[6] { 1, 2, 3, 4, 5, 6 };

            Cube cube = new Cube();
            Operations[] path = cube.Solve(n, startX, startY, numbers, targetX, targetY, value);

            if (path == null)
            {
                Console.WriteLine("No path!");
            }
            else
            {
                Console.WriteLine(path.Length);
                for (int i = 0; i < path.Length; i++)
                {
                    Console.WriteLine(path[i]);
                }
            }
            */
        }
    }
}