using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_49
{
    using System.Collections;

    class NPHard
    {
        private const int Pari = 1;

        private const int Arya = -1;

        private const int Neutral = 0;

        public int N { get; set; }
        
        public int M { get; set; }
        
        public List<int>[] Ribs { get; set; }

        public List<int> PariVertices { get; private set; }

        public List<int> AryaVertices { get; private set; }

        public bool Solve()
        {
            int[] colors = new int[this.N];

            for (int i = 0; i < this.N; i++)
            {
                colors[i] = Neutral;
            }

            Queue<int> queue = new Queue<int>();

            for (int startVertex = 0; startVertex < this.N; startVertex++)
            {
                if (!this.BFS(colors, startVertex, queue))
                {
                    return false;
                }
            }

            this.AryaVertices = new List<int>();
            this.PariVertices = new List<int>();

            for (int vertex = 0; vertex < this.N; vertex++)
            {
                if (colors[vertex] == Arya)
                {
                    this.AryaVertices.Add(vertex);
                }
                else if (colors[vertex] == Pari)
                {
                    this.PariVertices.Add(vertex);
                }
            }

            return true;
        }

        private bool BFS(int[] colors, int startVertex, Queue<int> queue)
        {
            if (colors[startVertex] != Neutral)
            {
                return true;
            }

            colors[startVertex] = Arya;
            queue.Clear();
            queue.Enqueue(startVertex);

            int currentVertex, nextColor;
            while (queue.Count > 0)
            {
                currentVertex = queue.Dequeue();
                nextColor = colors[currentVertex] == Arya ? Pari : Arya;

                foreach (int nextVertex in this.Ribs[currentVertex])
                {
                    if (colors[nextVertex] == Neutral)
                    {
                        colors[nextVertex] = nextColor;
                        queue.Enqueue(nextVertex);
                    } 
                    else if (colors[nextVertex] != nextColor)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
