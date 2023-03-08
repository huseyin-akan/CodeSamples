using CodeSamples.Design_Patterns.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns._TestPatterns
{
    public class MiddlewareTester :ITester
    {
        public void Test()
        {
            var pipe = new PipeBuilder(First) //First çalışan ana metot olucak. 
                .AddPipe(typeof(Try))
                .AddPipe(typeof(Wrap))
                .AddPipe(typeof(Wrap)) 
                .Build();

            pipe("Hello");
            pipe("World");
            pipe("This is Husoka!!!");
        }

        void First(string msg)
        {
            Console.WriteLine("The main/first method to invoke in the middleware: " + msg);
        }
    }
}
