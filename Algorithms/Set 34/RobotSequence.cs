using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_34
{
    public class RobotSequence
    {
        private static Dictionary<char, int> dx;
        private static Dictionary<char, int> dy;

        static RobotSequence()
        {
            dx = new Dictionary<char, int>()
            {
                { 'U', 0 },
                { 'D', 0 },
                { 'L', -1 },
                { 'R', 1 },
            };

            dy = new Dictionary<char, int>()
            {
                { 'U', 1 },
                { 'D', -1 },
                { 'L', 0 },
                { 'R', 0 },
            };
        }

        public static int Solve(int n, string input)
        {
            int x, y;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                x = 0;
                y = 0;
                for (int j = i; j < n; j++)
                {
                    x += dx[input[j]];
                    y += dy[input[j]];

                    if (x == 0 && y == 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
