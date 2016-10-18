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
            string[] coordsTokens;

            int n = Int32.Parse(System.Console.ReadLine());
            Point[] lamps = new Point[n];
            for (int i = 0; i < n; i++)
            {
                coordsTokens = System.Console.ReadLine().Split(new char[] { ' ' });
                lamps[i] = new Point { X = Int32.Parse(coordsTokens[0]), Y = Int32.Parse(coordsTokens[1]) };
            }

            int m = Int32.Parse(System.Console.ReadLine());
            Point[] coords = new Point[m];
            for (int i = 0; i < m; i++)
            {
                coordsTokens = System.Console.ReadLine().Split(new char[] { ' ' });
                coords[i] = new Point { X = Int32.Parse(coordsTokens[0]), Y = Int32.Parse(coordsTokens[1]) };
            }

            bool[] result = Set54Lamps.Solve(lamps, coords);

            for (int i = 0; i < m; i++)
            {
                System.Console.WriteLine(result[i]);
            }
        }
    }
}
