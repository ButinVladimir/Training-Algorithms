using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public class AppleOrange
    {
        public int S { get; set; }
        public int T { get; set; }
        public int A { get; set; }
        public int B { get; set; }

        public bool DoesAppleCount(int d)
        {
            return this.DoesCount(this.A + d);
        }

        public bool DoesOrangeCount(int d)
        {
            return this.DoesCount(this.B + d);
        }

        private bool DoesCount(int coord)
        {
            return coord >= this.S && coord <= this.T;
        }
    }
}
