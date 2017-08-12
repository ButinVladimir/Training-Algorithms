using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_12
{
    public class StringsChain
    {
        public string[] Words { get; set; }
        private Dictionary<char, List<int>> ribs;
        private Dictionary<char, int> ribsPos;
        private Dictionary<char, int> countIn;
        private Dictionary<char, int> countOut;
        private char? start;
        private char? finish;
        private LinkedList<char> path;

        public string Solve()
        {
            this.Prepare();

            if (!this.FindStartAndEndPositions())
            {
                return null;
            }

            if (!this.Travel())
            {
                return null;
            }

            return null;
        }

        private void Prepare()
        {
            this.ribs = new Dictionary<char, List<int>>();
            this.ribsPos = new Dictionary<char, int>();
            this.countIn = new Dictionary<char, int>();
            this.countOut = new Dictionary<char, int>();
            this.path = new LinkedList<char>();

            for (int i = 0; i < this.Words.Length; i++)
            {
                string word = this.Words[i];
                char first = word.First();
                char last = word.Last();

                if (!this.ribs.ContainsKey(first))
                {
                    this.ribs[first] = new List<int>();
                    this.ribsPos[first] = 0;
                }

                this.ribs[first].Add(i);

                if (!this.countIn.ContainsKey(first))
                {
                    this.countIn[first] = 0;
                }
                this.countIn[first]++;

                if (!this.countOut.ContainsKey(last))
                {
                    this.countOut[last] = 0;
                }
                this.countOut[last]++;
            }
        }

        private bool FindStartAndEndPositions()
        {
            int cin, cout;
            this.start = null;
            this.finish = null;

            foreach (var kv in this.countIn)
            {
                cin = kv.Value;
                cout = this.countOut.ContainsKey(kv.Key) ? this.countOut[kv.Key] : 0;

                if (cin == cout + 1)
                {
                    if (this.start == null)
                    {
                        this.start = kv.Key;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (cin > cout + 1)
                {
                    return false;
                }
            }

            foreach (var kv in this.countOut)
            {
                cout = kv.Value;
                cin = this.countIn.ContainsKey(kv.Key) ? this.countIn[kv.Key] : 0;

                if (cout == cin + 1)
                {
                    if (this.finish == null)
                    {
                        this.finish = kv.Key;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (cout > cin + 1)
                {
                    return false;
                }
            }

            if (this.start == null && this.finish != null || this.start != null && this.finish == null)
            {
                return false;
            }

            if (this.start == null && this.finish == null)
            {
                this.start = this.finish = this.countIn.First().Key;
            }

            if (!this.ribs.ContainsKey(this.finish.Value))
            {
                this.ribs[this.finish.Value] = new List<int>();
                this.ribsPos[this.finish.Value] = 0;
            }

            this.ribs[this.finish.Value].Add(-1);

            return true;
        }

        private bool Travel()
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(this.start.Value);

            while (stack.Count > 0)
            {
                char current = stack.Peek();
                if (this.ribsPos[current] == this.ribs[current].Count)
                {
                    this.path.AddFirst(current);
                    stack.Pop();
                }
                else
                {
                    stack.Push(this.Words[this.ribs[current][this.ribsPos[current]]].Last());
                    this.ribsPos[current]++;
                }
            }

            foreach (var kv in this.ribs)
            {
                if (this.ribsPos[kv.Key] != kv.Value.Count)
                {
                    return false;
                }
            }

            return true;
        }

        private string MakeOutput()
        {
            char[] pathArray = this.path.ToArray();

            int pos = 0;
            while (pathArray[pos] != this.finish.Value || pathArray[pos+1] != this.start.Value)
        }
    }
}
