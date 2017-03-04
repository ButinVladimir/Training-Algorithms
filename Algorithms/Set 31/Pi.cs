using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_31
{
    public class Pi
    {
        public static double Solve(int precision)
        {
            if (precision < 1)
            {
                throw new ArgumentException("Precision should be greater than 0");
            }

            double dx = 1.0 / precision;
            double x = 1;
            double y = 0;
            double nx, ny;
            double result = 0;

            for (int i = 0; i < precision; i++)
            {
                nx = x - dx;
                ny = Math.Sqrt(1 - nx * nx);

                result += Math.Abs(ny - y) * (x + nx);

                x = nx;
                y = ny;
            }

            return result * 2;
        }
    }
}
