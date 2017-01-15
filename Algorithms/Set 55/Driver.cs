using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_55
{
    class Driver
    {
        private IList<Road>[] adjacencyList;

        public int N { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public IList<Road> Roads { get; set; }
        public int Cu { get; set; }
        public int Lu { get; set; }

        public Path Solve()
        {
            this.SetAdjacencyList();
            Path result = null;

            int c = 0;
            int step = Cu;
            int nextC;

            while (step > 0)
            {
                nextC = c + step;

                if (nextC <= Cu && Solve(nextC) == null)
                {
                    c = nextC;
                }
                else
                {
                    step /= 2;
                }
            }

            c++;
            if (c <= Cu)
            {
                result = Solve(c);
            }

            return result;
        }

        private void SetAdjacencyList()
        {
            this.adjacencyList = new List<Road>[N];

            for (int i = 0; i < N; i++)
            {
                this.adjacencyList[i] = new List<Road>();
            }

            foreach (Road road in Roads)
            {
                this.adjacencyList[road.From].Add(road);
                this.adjacencyList[road.To].Add(road);
            }
        }

        private Path Solve(int Cu)
        {
            int[] dist = new int[N];
            int[] pred = new int[N];
            bool[] fl = new bool[N];

            for (int i = 0; i < N; i++)
            {
                dist[i] = Lu + 1;
                fl[i] = false;
                pred[i] = -1;
            }

            dist[Start] = 0;
            int nextVertice, to;

            for (int iteration = 0; iteration < N; iteration++)
            {
                nextVertice = -1;

                for (int i = 0; i < N; i++)
                {
                    if (fl[i] == false && dist[i] <= Lu && (nextVertice == -1 || dist[i] < dist[nextVertice]))
                    {
                        nextVertice = i;
                    }
                }

                if (nextVertice == -1)
                {
                    break;
                }

                fl[nextVertice] = true;

                foreach (var road in this.adjacencyList[nextVertice])
                {
                    if (road.Cost > Cu)
                    {
                        continue;
                    }

                    to = road.From == nextVertice ? road.To : road.From;

                    if (dist[to] > dist[nextVertice] + road.Length)
                    {
                        dist[to] = dist[nextVertice] + road.Length;
                        pred[to] = nextVertice;
                    }
                }
            }

            if (dist[Finish] == Lu + 1)
            {
                return null;
            }

            List<int> path = new List<int>();
            int vertex = Finish;
            while (vertex != Start)
            {
                path.Add(vertex);
                vertex = pred[vertex];
            }

            path.Add(Start);
            path.Reverse();

            return new Path()
            {
                C = Cu,
                L = dist[Finish],
                Roads = path
            };
        }

        public class Road
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Cost { get; set; }
            public int Length { get; set; }
        }

        public class Path
        {
            public int C { get; set; }
            public int L { get; set; }
            public IList<int> Roads { get; set; }
        }
    }
}
