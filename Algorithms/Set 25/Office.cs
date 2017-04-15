using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_25
{
    public interface IOffice
    {
        long QueryRow(int row);
        long QueryColumn(int column);
    }

    public class Office : IOffice
    {
        private int n;
        private SortedSet<int> rows;
        private SortedSet<int> cols;
        private long colSum;
        private long rowSum;

        public Office(int n)
        {
            this.rows = new SortedSet<int>();
            this.cols = new SortedSet<int>();
            this.n = n;

            this.rowSum = this.colSum = (1 + n) * n / 2;
        }

        public long QueryRow(int row)
        {
            return this.Calculate(row, rows, cols, ref rowSum, ref colSum);
        }

        public long QueryColumn(int col)
        {
            return this.Calculate(col, cols, rows, ref colSum, ref rowSum);
        }

        private long Calculate(int pos, SortedSet<int> alongs, SortedSet<int> crosses, ref long alongSum, ref long acrossSum)
        {
            long result = alongSum;

            if (!alongs.Contains(pos))
            {
                result += (this.n - crosses.Count) * pos;
                alongs.Add(pos);
                acrossSum -= pos;
            }
            else
            {
                return 0;
            }

            return result;
        }
    }

    public class OfficeSimple : IOffice
    {
        private int n;
        private long[,] vals;

        public OfficeSimple(int n)
        {
            this.n = n;

            this.vals = new long[n, n];
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < n; j++)
                {
                    this.vals[i, j] = i + 1 + j + 1;
                }
            }
        }

        public long QueryColumn(int column)
        {
            long result = 0;
            column--;

            for (int i = 0; i < n; i++)
            {
                result += this.vals[i, column];
                this.vals[i, column] = 0;
            }

            return result;
        }

        public long QueryRow(int row)
        {
            long result = 0;
            row--;

            for (int i = 0; i < n; i++)
            {
                result += this.vals[row, i];
                this.vals[row, i] = 0;
            }

            return result;
        }
    }

    [TestClass]
    public class OfficeTest
    {
        [TestMethod]
        public void Test1()
        {
            this.Test(3, new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void Test2()
        {
            this.Test(3, new int[] { 1, -2, 3 });
        }

        [TestMethod]
        public void Test3()
        {
            this.Test(3, new int[] { -1, 2, -3 });
        }

        [TestMethod]
        public void Test4()
        {
            this.Test(10, new int[] { 1, 1, 2, 2, -3, 4, 9, -2, -3, -7, 6, 8 });
        }

        private void Test(int n, int[] commands)
        {
            Office real = new Office(n);
            OfficeSimple simple = new OfficeSimple(n);

            long simpleResult, realResult;
            foreach (int command in commands)
            {
                if (command > 0)
                {
                    simpleResult = simple.QueryRow(command);
                    realResult = real.QueryRow(command);
                }
                else
                {
                    simpleResult = simple.QueryColumn(-command);
                    realResult = real.QueryColumn(-command);
                }

                Assert.AreEqual(simpleResult, realResult);
            }
        }
    }
}
