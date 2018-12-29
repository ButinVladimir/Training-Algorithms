using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public class CityOfBlindingLights
    {
        private int n;
        private long[,] ribs;
        private long[,] paths;

        public CityOfBlindingLights(int n)
        {
            this.n = n;
            this.ribs = new long[this.n, this.n];
            this.paths = new long[this.n, this.n];

            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    this.ribs[i, j] = -1;
                    this.paths[i, j] = -1;
                }
            }

            for (int i = 0; i < this.n; i++)
            {
                this.ribs[i, i] = 0;
                this.paths[i, i] = 0;
            }
        }

        public void SetRib(int from, int to, long v)
        {
            from--;
            to--;
            this.ribs[from, to] = v;
            this.paths[from, to] = v;
        }

        public void ComputePaths()
        {
            for (int k = 0; k < this.n; k++)
            {
                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < this.n; j++)
                    {
                        if (this.paths[i, k] != -1 && this.paths[k, j] != -1 && (this.paths[i, j] == -1 || this.paths[i, j] > this.paths[i, k] + this.paths[k, j]))
                        {
                            this.paths[i, j] = this.paths[i, k] + this.paths[k, j];
                        }
                    }
                }
            }
        }

        public long Query(int from, int to)
        {
            from--;
            to--;

            return this.paths[from, to];
        }
    }
}
