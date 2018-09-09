using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public interface Interface1
    {

    }

    public interface Interface2
    {

    }

    public interface Interface3: Interface1, Interface2
    {

    }

    public class TestClass: Interface3
    {

    }

    public static class TestStaticClass
    {
        public static void Output(this IEnumerable<Interface3> t)
        {
            Console.WriteLine("Marco");
        }

        public static void Output(this IEnumerable<Interface2> t)
        {
            Console.WriteLine("Polo");
        }
    }
}
