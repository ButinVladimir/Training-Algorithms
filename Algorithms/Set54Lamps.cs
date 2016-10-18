using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamps
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Set54Lamps
    {
        public static bool[] Solve(Point[] lamps, Point[] coords)
        {
            int m = coords.Length;
            bool[] result = new bool[m];

            SortedSet<int> verticals = new SortedSet<int>()
                , horizontals = new SortedSet<int>()
                , mainDiagonals = new SortedSet<int>()
                , secondaryDiagonals = new SortedSet<int>();

            foreach (Point lamp in lamps)
            {
                verticals.Add(lamp.X);
                horizontals.Add(lamp.Y);
                mainDiagonals.Add(lamp.X - lamp.Y);
                secondaryDiagonals.Add(lamp.X + lamp.Y);
            }

            for (int i = 0; i < coords.Length; i++)
            {
                result[i] = verticals.Contains(coords[i].X)
                    || horizontals.Contains(coords[i].Y)
                    || mainDiagonals.Contains(coords[i].X - coords[i].Y)
                    || secondaryDiagonals.Contains(coords[i].X + coords[i].Y);
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

    *
    */
