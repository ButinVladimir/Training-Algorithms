using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Merging
    {
        private int[] leader;
        private int[] size;

        public Merging(int n)
        {
            this.leader = new int[n];
            this.size = new int[n];

            for (int i = 0; i < n; i++)
            {
                this.leader[i] = i;
                this.size[i] = 1;
            }
        }

        public int Get(int pos)
        {
            return this.size[this.GetLeader(pos)];
        }

        public void Merge(int posA, int posB)
        {
            posA = this.GetLeader(posA);
            posB = this.GetLeader(posB);

            if (posA == posB)
            {
                return;
            }

            if (this.size[posB] < this.size[posA])
            {
                this.leader[posB] = posA;
                this.size[posA] += this.size[posB];
            }
            else
            {
                this.leader[posA] = posB;
                this.size[posB] += this.size[posA];
            }
        }

        private int GetLeader(int pos)
        {
            if (this.leader[pos] == pos)
            {
                return pos;
            }

            this.leader[pos] = this.GetLeader(this.leader[pos]);
            return this.leader[pos];
        }
    }
}
