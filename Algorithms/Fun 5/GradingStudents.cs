using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class GradingStudents
    {
        public static void Solve(int[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 38)
                {
                    continue;
                }

                int m = 5 - grades[i] % 5;
                if (m < 3)
                {
                    grades[i] += m;
                }
            }
        }
    }
}
