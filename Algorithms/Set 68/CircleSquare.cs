using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_68
{
    public class CircleSquare
    {
        public static string[] Solve(long w, long h, long xc, long yc, long r, long x1, long y1, long x3, long y3)
        {
            string[] result = new string[h];
            StringBuilder sb = new StringBuilder();

            bool add;
            long r2 = r * r;

            for (long y = 0; y < h; y++)
            {
                sb.Clear();
                for (long x = 0; x < w; x++)
                {
                    add = false;

                    if (Distance(xc, yc, x, y) <= r2)
                    {
                        add = true;
                    }

                    if (CheckSquareAngle(x, y, x1, y1, x3, y3) && CheckSquareAngle(x, y, x3, y3, x1, y1))
                    {
                        add = true;
                    }

                    sb.Append(add ? '#' : '.');
                }

                result[y] = sb.ToString();
            }

            return result;
        }

        private static bool CheckSquareAngle(long x, long y, long x1, long y1, long x3, long y3)
        {
            long mult = (x - x1) * (x3 - x1) + (y - y1) * (y3 - y1);
            if (mult < 0)
            {
                return false;
            }

            long left = 2 * mult * mult;
            long right = Distance(x1, y1, x, y) * Distance(x1, y1, x3, y3);
            return left >= right;
        }

        private static long Distance(long x1, long y1, long x2, long y2)
        {
            long dx = x2 - x1;
            long dy = y2 - y1;

            return dx * dx + dy * dy;
        }
    }
}
