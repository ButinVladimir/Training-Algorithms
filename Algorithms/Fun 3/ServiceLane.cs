using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public class ServiceLane
    {
        private int[] width;
        int[,] prev;

        public ServiceLane(int[] width)
        {
            this.width = width;
            int n = this.width.Length;

            this.prev = new int[3, n];
            int[] current = new int[3];
            int w;

            for (int i = 0; i < 3; i++)
            {
                this.prev[i, 0] = -1;
                current[i] = -1;
            }

            w = width[0] - 1;
            this.prev[w, 0] = current[w] = 0;

            for (int position = 1; position < n; position++)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.prev[i, position] = current[i];
                }

                w = this.width[position] - 1;
                this.prev[w, position] = current[w] = position;
            }
        }

        public int Query(int from, int to)
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.prev[i, to] >= from)
                {
                    return i + 1;
                }
            }

            return 3;
        }
    }
}
