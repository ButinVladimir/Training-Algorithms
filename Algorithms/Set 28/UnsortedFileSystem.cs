using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public class UnsortedFileSystem : FileSystem
    {
        private int[] values;

        public UnsortedFileSystem(int[] values)
        {
            this.values = new int[values.Length];
            values.CopyTo(this.values, 0);
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
