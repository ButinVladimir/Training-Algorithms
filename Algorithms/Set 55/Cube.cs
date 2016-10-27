using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_55
{
    enum Operations { Left, Right, Up, Down, Stop };

    internal class CubeState
    {
        public const int TOP = 0;
        public const int BOTTOM = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;
        public const int FRONT = 4;
        public const int BACK = 5;
        public const int SIDES = 6;

        public int[] Numbers { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }
        public Operations Operation { get; set; }
        public CubeState Previous { get; set; }

        public CubeState()
        {
            this.Numbers = new int[SIDES];
            this.X = 0;
            this.Y = 0;
            this.Distance = 0;
            this.Operation = Operations.Stop;
        }

        public CubeState(int[] numbers, int x, int y, int distance, Operations operation, CubeState previous)
        {
            this.Numbers = (int[])numbers.Clone();
            this.X = x;
            this.Y = y;
            this.Distance = distance;
            this.Operation = operation;
            this.Previous = previous;
        }

        public bool Check(int N)
        {
            return this.X >= 0 && this.X < N && this.Y >= 0 && this.Y < N;
        }

        public int ToCode()
        {
            int multiplier = 1, result = 0;
            for (int i = 0; i < SIDES; i++, multiplier *= 10)
            {
                result += multiplier * this.Numbers[i];
            }

            return result;
        }

        public CubeState Up()
        {
            CubeState result = new CubeState(this.Numbers, this.X, this.Y - 1, this.Distance + 1, Operations.Up, this);
            result.Numbers[TOP] = this.Numbers[FRONT];
            result.Numbers[BACK] = this.Numbers[TOP];
            result.Numbers[BOTTOM] = this.Numbers[BACK];
            result.Numbers[FRONT] = this.Numbers[BOTTOM];

            return result;
        }

        public CubeState Down()
        {
            CubeState result = new CubeState(this.Numbers, this.X, this.Y + 1, this.Distance + 1, Operations.Down, this);
            result.Numbers[BOTTOM] = this.Numbers[FRONT];
            result.Numbers[BACK] = this.Numbers[BOTTOM];
            result.Numbers[TOP] = this.Numbers[BACK];
            result.Numbers[FRONT] = this.Numbers[TOP];

            return result;
        }

        public CubeState Left()
        {
            CubeState result = new CubeState(this.Numbers, this.X - 1, this.Y, this.Distance + 1, Operations.Left, this);
            result.Numbers[LEFT] = this.Numbers[FRONT];
            result.Numbers[BACK] = this.Numbers[LEFT];
            result.Numbers[RIGHT] = this.Numbers[BACK];
            result.Numbers[FRONT] = this.Numbers[RIGHT];

            return result;
        }

        public CubeState Right()
        {
            CubeState result = new CubeState(this.Numbers, this.X + 1, this.Y, this.Distance + 1, Operations.Right, this);
            result.Numbers[RIGHT] = this.Numbers[FRONT];
            result.Numbers[BACK] = this.Numbers[RIGHT];
            result.Numbers[LEFT] = this.Numbers[BACK];
            result.Numbers[FRONT] = this.Numbers[LEFT];

            return result;
        }
    }

    class Cube
    {
        private Dictionary<int, CubeState>[,] grid;
        private int n;

        private Operations[] MakePath(CubeState finishState)
        {
            Operations[] operations = new Operations[finishState.Distance];
            CubeState currentState = finishState;

            int index = finishState.Distance - 1;
            while (currentState.Operation != Operations.Stop)
            {
                operations[index] = currentState.Operation;
                currentState = currentState.Previous;
                index--;
            }

            return operations;
        }

        private bool CheckState(CubeState cubeState)
        {
            if (this.grid[cubeState.X, cubeState.Y] != null && this.grid[cubeState.X, cubeState.Y].ContainsKey(cubeState.ToCode()))
            {
                return false;
            }

            return true;
        }

        private void pushState(CubeState cubeState)
        {
            if (this.grid[cubeState.X, cubeState.Y] == null)
            {
                this.grid[cubeState.X, cubeState.Y] = new Dictionary<int, CubeState>();
            }

            grid[cubeState.X, cubeState.Y][cubeState.ToCode()] = cubeState;
        }

        public Operations[] Solve(int n, int startX, int startY, int[] numbers, int targetX, int targetY, int value)
        {
            this.n = n;
            this.grid = new Dictionary<int, CubeState>[n, n];
            CubeState currentCubeState = new CubeState(numbers, startX, startY, 0, Operations.Stop, null);
            pushState(currentCubeState);
            CubeState[] newCubeStates;
            Queue<CubeState> queue = new Queue<CubeState>();

            queue.Enqueue(currentCubeState);
            while (queue.Count > 0)
            {
                currentCubeState = queue.Dequeue();

                if (currentCubeState.X == targetX && currentCubeState.Y == targetY && currentCubeState.Numbers[CubeState.BACK] == value)
                {
                    return this.MakePath(currentCubeState);
                }

                newCubeStates = new CubeState[4] { currentCubeState.Up(), currentCubeState.Down(), currentCubeState.Left(), currentCubeState.Right() };

                foreach (CubeState newCubeState in newCubeStates)
                {
                    if (newCubeState.Check(n) && this.CheckState(newCubeState))
                    {
                        pushState(newCubeState);
                        queue.Enqueue(newCubeState);
                    }
                }
            }

            return null;
        }
    }
}

