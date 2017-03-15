using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_69
{
    public class Min
    {
        public static string Solve(int n)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n - 1; i++)
            {
                sb.Append("min(int, ");
            }
            sb.Append("int");
            sb.Append(')', n - 1);

            return sb.ToString();
        }
    }
}
