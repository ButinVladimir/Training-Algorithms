using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public class AChessboardGame
    {
        private const int N = 15;
        private static readonly int[] dx = { -2, -2, -1, 1 };
        private static readonly int[] dy = { -1, 1, -2, -2 };
        IDictionary<Tuple<int, int>, bool> results = new Dictionary<Tuple<int, int>, bool>();

        public bool Solve(int x, int y)
        {
            bool result;
            var key = new Tuple<int, int>(x, y);
            if (this.results.TryGetValue(key, out result))
            {
                return result;
            }

            result = false;
            int nx, ny;
            for (int i = 0; i < 4; i++)
            {
                nx = x + dx[i];
                ny = y + dy[i];
                if (nx >= 1 && ny >= 1 && nx <= N && ny <= N && !this.Solve(nx, ny))
                {
                    result = true;
                }
            }

            this.results[key] = result;

            return result;
        }
    }
}
