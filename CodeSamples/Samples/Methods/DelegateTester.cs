using CodeSamples.Samples.Methods.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Samples.Methods
{
    public class DelegateTester
    {
        public void TestDelegate(HusolaDelegate function, string name)
        {
            Console.WriteLine("function hasnt been invoked yet");
            function(name);
            Console.WriteLine("function has been invoked");
        }

        public void Husolayalim(string name)
        {
            Console.WriteLine(name + " husolanmıştır. Tebrikler");
        }

        public void TestDelegate(Action function)
        {
            Console.WriteLine("function hasnt been invoked yet");
            function();
            function.Invoke();
            Console.WriteLine("function has been invoked");
        }

    }

}
