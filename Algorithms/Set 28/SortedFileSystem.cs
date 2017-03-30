using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public class SortedFileSystem : FileSystem
    {
        private int[] values;

        public SortedFileSystem(int[] values)
        {
            this.values = new int[values.Length];
            values.CopyTo(this.values, 0);
            Array.Sort(this.values);
        }

        public int GetCount()
        {
            return this.values.Length;
        }

        public int GetValue(int position)
        {
            if (position < 0 || position >= this.GetCount())
            {
                throw new IndexOutOfRangeException();
            }

            return this.values[position];
        }
    }
}
