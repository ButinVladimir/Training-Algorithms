using System;
using System.Collections.Generic;

namespace Algorithms.Set_61
{
    public class ABCPATH
    {
        private const int DIRECTIONS = 8;
        private const char ZERO = '\0';
        private static readonly int[] deltaX = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        private static readonly int[] deltaY = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

        internal class Coords
        {
            public int X { get; set; }

            public int Y { get; set; }

            public Coords(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public static int Solve(int h, int w, string[] letters)
        {
            bool[,] usedLetters = new bool[h, w];
            Queue<Coords> coordsQueue = new Queue<Coords>();
            int x, y;
            char maxLetter = ZERO;

            for (y = 0; y < h; y++)
            {
                for (x = 0; x < w; x++)
                {
                    if (letters[y][x] == 'A')
                    {
                        coordsQueue.Enqueue(new Coords(x, y));
                        usedLetters[y, x] = true;
                        maxLetter = 'A';
                    }
                }
            }

            while (coordsQueue.Count > 0)
            {
                Coords currentCoords = coordsQueue.Dequeue();

                for (int direction = 0; direction < DIRECTIONS; direction++)
                {
                    x = currentCoords.X + deltaX[direction];
                    y = currentCoords.Y + deltaY[direction];

                    if ((x >= 0) &&
                        (x < w) &&
                        (y >= 0) &&
                        (y < h) &&
                        (usedLetters[y, x] == false) &&
                        (letters[y][x] == letters[currentCoords.Y][currentCoords.X] + 1)
                       )
                    {
                        if (letters[y][x] > maxLetter)
                        {
                            maxLetter = letters[y][x];
                        }

                        coordsQueue.Enqueue(new Coords(x, y));
                        usedLetters[y, x] = true;
                    }
                }
            }

            return maxLetter == ZERO ? 0 : Convert.ToInt32(maxLetter - 'A' + 1);
        }
    }
}