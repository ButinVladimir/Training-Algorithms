using System;
using System.Collections.Generic;

namespace Algorithms.Set_62
{
    public class Dfloor
    {
        private const int D = 5;
        private static int[] dx;
        private static int[] dy;

        static Dfloor()
        {
            dx = new int[D] { 0, -1, 1, 0, 0 };
            dy = new int[D] { 0, 0, 0, -1, 1 };
        }

        public static List<Tuple<int, int>> Solve(int x, int y, char[,] arr)
        {
            int xy = x * y;
            int[,] vars = new int[xy, xy];
            int[] vals = new int[xy];

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int k = 0; k < D; k++)
                    {
                        int xpos = i + dx[k];
                        int ypos = j + dy[k];

                        if (xpos >= 0 && xpos < x && ypos >= 0 && ypos < y)
                        {
                            vars[EncodeCoords(i, j, x), EncodeCoords(xpos, ypos, x)] = 1;
                        }
                    }

                    vals[EncodeCoords(i, j, x)] = arr[j, i] == '1' ? 0 : 1;
                }
            }

            bool[] used = new bool[xy];

            int?[] result = new int?[xy];
            for (int i = 0; i < xy; i++)
            {
                result[i] = null;
            }

            for (int i = 0; i < xy; i++)
            {
                int next;
                for (next = 0; next < xy && (used[next] || vars[next, i] == 0); next++) ;

                if (next == xy)
                {
                    result[i] = 0;
                }
                else
                {
                    used[next] = true;

                    for (int j = 0; j < xy; j++)
                    {
                        if (j == next || vars[j, i] == 0)
                        {
                            continue;
                        }

                        for (int k = 0; k < xy; k++)
                        {
                            vars[j, k] = Sum(vars[j, k], vars[next, k]);
                        }

                        vals[j] = Sum(vals[j], vals[next]);
                    }
                }
            }

            for (int i = 0; i < xy; i++)
            {
                for (int j = 0; j < xy; j++)
                {
                    if (vars[i, j] == 1 && result[j] == null)
                    {
                        result[j] = vals[i];
                    }
                }
            }

            List<Tuple<int, int>> answer = new List<Tuple<int, int>>();
            for (int i = 0; i < xy; i++)
            {
                if (result[i] == 1)
                {
                    int xpos, ypos;
                    DecodeCoords(i, x, out xpos, out ypos);
                    answer.Add(new Tuple<int, int>(xpos, ypos));

                    for (int j = 0; j < D; j++)
                    {
                        int xp = xpos + dx[j];
                        int yp = ypos + dy[j];

                        if (xp >= 0 && xp < x && yp >= 0 && yp < y)
                        {
                            arr[yp, xp] = arr[yp, xp] == '1' ? '0' : '1';
                        }
                    }
                }
            }

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    if (arr[j, i] == '0')
                    {
                        return null;
                    }
                }
            }

            return answer;
        }

        private static int EncodeCoords(int xpos, int ypos, int x)
        {
            return ypos * x + xpos;
        }

        private static void DecodeCoords(int coords, int x, out int xpos, out int ypos)
        {
            xpos = coords % x;
            ypos = coords / x;
        }

        private static int Sum(int x, int y)
        {
            if (x == 1 && y == 1)
            {
                return 0;
            }

            return x + y;
        }
    }
}