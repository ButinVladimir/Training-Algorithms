using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public class GameOfStones
    {
        private const int N = 100;
        private bool[] win = new bool[200];

        public void PrepareData()
        {
            win[0] = false;
            win[1] = false;

            for (int i = 2; i <= N; i++)
            {
                win[i] = !this.CanWin(i - 2) || !this.CanWin(i - 3) || !this.CanWin(i - 5);
            }
        }

        public bool Solve(int n)
        {
            return this.win[n];
        }

        private bool CanWin(int rem)
        {
            return rem >= 0 && win[rem];
        }
    }
}
