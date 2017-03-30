using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public class UnsortedFileSystemQuery : FileSystemQuery
    {
        private List<UnsortedFileSystem> fileSystems = new List<UnsortedFileSystem>();

        public void AddFileSystem(UnsortedFileSystem system)
        {
            this.fileSystems.Add(system);
        }

        public int GetKthValue(int k)
        {
            return this.GetKthValue(k, this.fileSystems.ConvertAll(x => (FileSystem)x).ToList<FileSystem>());
        }

        protected override int GetMin()
        {
            int min = 0;
            bool was = false;

            foreach (UnsortedFileSystem system in this.fileSystems)
            {
                for (int i = 0; i < system.GetCount(); i++)
                {
                    if (!was || system.GetValue(i) < min)
                    {
                        was = true;
                        min = system.GetValue(i);
                    }
                }
            }

            return min;
        }

        protected override int GetMax()
        {
            int max = 0;
            bool was = false;

            foreach (UnsortedFileSystem system in this.fileSystems)
            {
                for (int i = 0; i < system.GetCount(); i++)
                {
                    if (!was || system.GetValue(i) > max)
                    {
                        was = true;
                        max = system.GetValue(i);
                    }
                }
            }

            return max;
        }

        protected override int GetLesserOrEqual(int value)
        {
            int count = 0;

            foreach (UnsortedFileSystem system in this.fileSystems)
            {
                for (int i = 0; i < system.GetCount(); i++)
                {
                    if (system.GetValue(i) <= value)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
