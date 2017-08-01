using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_12
{
    public static class Abs
    {
        public static string Solve(int value)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Convert.ToString(value, 2));

            int a = value >> 31;
            sb.AppendLine(Convert.ToString(a, 2));

            int b = value ^ a;
            sb.AppendLine(Convert.ToString(b, 2));

            int c = a & 1;
            sb.AppendLine(Convert.ToString(c, 2));

            Console.WriteLine(sb.ToString());

            return (b + c).ToString();
        }
    }
}
