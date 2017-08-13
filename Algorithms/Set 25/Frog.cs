using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_25
{
    public abstract class Frog
    {
        private bool[] stones;
        private SortedSet<Tuple<int, int>> visited;

        public Frog(bool[] stones)
        {
            int n = stones.Length;
            this.stones = new bool[n + 2];

            stones.CopyTo(this.stones, 1);
            this.stones[0] = true;
            this.stones[n + 1] = true;
        }

        protected abstract int NextStep(int prevStep);

        public bool Check()
        {
            this.visited = new SortedSet<Tuple<int, int>>();

            for (int i = 1; i < this.stones.Length - 1; i++)
            {
                if (this.Check(i))
                {
                    return true;
                }
            }

            return false;
        }

        private bool Check(int initStep)
        {
            if (this.visited.Contains(new Tuple<int, int>(0, initStep)))
            {
                return false;
            }
            this.visited.Add(new Tuple<int, int>(0, initStep));

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, initStep));

            int to, from, step, nextStep;
            while (queue.Count > 0)
            {
                var queueHead = queue.Dequeue();

                from = queueHead.Item1;
                step = queueHead.Item2;

                if (from == this.stones.Length - 1)
                {
                    return true;
                }

                nextStep = this.NextStep(step);

                if (nextStep < 0)
                {
                    continue;
                }

                to = from + step;
                var newTuple = new Tuple<int, int>(to, nextStep);
                if (CanVisit(to) && !this.visited.Contains(newTuple))
                {
                    queue.Enqueue(newTuple);
                    this.visited.Add(newTuple);
                }

                to = from - step;
                newTuple = new Tuple<int, int>(to, nextStep);
                if (CanVisit(to) && !this.visited.Contains(newTuple))
                {
                    queue.Enqueue(newTuple);
                    this.visited.Add(newTuple);
                }
            }

            return false;
        }

        private bool CanVisit(int pos)
        {
            return pos >= 0 && pos < this.stones.Length && this.stones[pos] == true;
        }
    }

    public class FrogSame : Frog
    {
        public FrogSame(bool[] stones) : base(stones)
        {
        }

        protected override int NextStep(int prevStep)
        {
            return prevStep;
        }
    }

    public class FrogDecrease : Frog
    {
        public FrogDecrease(bool[] stones) : base(stones)
        {
        }

        protected override int NextStep(int prevStep)
        {
            return prevStep - 1;
        }
    }

    public class FrogIncrease : Frog
    {
        public FrogIncrease(bool[] stones) : base(stones)
        {
        }

        protected override int NextStep(int prevStep)
        {
            return prevStep + 1;
        }
    }

    [TestClass]
    public class FrogTest
    {
        [TestMethod]
        public void Test1()
        {
            bool[] stones = new bool[] {
                false,
                true,
                true,
                false,
                true};

            FrogSame fs = new FrogSame(stones);
            FrogIncrease fi = new FrogIncrease(stones);
            FrogDecrease fd = new FrogDecrease(stones);

            Assert.IsTrue(fs.Check());
            Assert.IsFalse(fi.Check());
            Assert.IsTrue(fd.Check());
        }

        [TestMethod]
        public void Test2()
        {
            bool[] stones = new bool[] {
                true,
                false,
                true,
                false,
                false};

            FrogSame fs = new FrogSame(stones);
            FrogIncrease fi = new FrogIncrease(stones);
            FrogDecrease fd = new FrogDecrease(stones);

            Assert.IsTrue(fs.Check());
            Assert.IsTrue(fi.Check());
            Assert.IsFalse(fd.Check());
        }

        [TestMethod]
        public void Test3()
        {
            bool[] stones = new bool[] {
                true,
                false,
                true,
                false,
                false,
                true,
                false,
                false,
                false };

            FrogSame fs = new FrogSame(stones);
            FrogIncrease fi = new FrogIncrease(stones);
            FrogDecrease fd = new FrogDecrease(stones);

            Assert.IsFalse(fs.Check());
            Assert.IsTrue(fi.Check());
            Assert.IsFalse(fd.Check());
        }

        [TestMethod]
        public void Test4()
        {
            bool[] stones = new bool[] {
                false,
                false,
                false,
                true,
                false,
                false,
                true,
                false,
                true };

            FrogSame fs = new FrogSame(stones);
            FrogIncrease fi = new FrogIncrease(stones);
            FrogDecrease fd = new FrogDecrease(stones);

            Assert.IsFalse(fs.Check());
            Assert.IsFalse(fi.Check());
            Assert.IsTrue(fd.Check());
        }
    }

}
