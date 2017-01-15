using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_57
{
    class Folding
    {
        public static int Solve(int W, int H, int w, int h)
        {
            int result = -1;

            int buffer = TransformRectangle(W, H, w, h);
            if (buffer != -1 && (result == -1 || result > buffer))
            {
                result = buffer;
            }

            buffer = TransformRectangle(H, W, w, h);
            if (buffer != -1 && (result == -1 || result > buffer))
            {
                result = buffer;
            }

            return result;
        }

        private static int TransformRectangle(int W, int H, int w, int h)
        {
            if (W >= w && H >= h)
            {
                return TransformSide(W, w) + TransformSide(H, h);
            }

            return -1;
        }

        private static int TransformSide(int x, int y)
        {
            if (y > x)
            {
                return -1;
            }

            if (y == x)
            {
                return 0;
            }

            int result = 1;
            while (y < x / 2 + x % 2)
            {
                x = x / 2 + x % 2;
                result++;
            }

            return result;
        }
    }
}
