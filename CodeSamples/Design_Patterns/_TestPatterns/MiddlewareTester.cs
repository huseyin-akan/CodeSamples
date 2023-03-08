using CodeSamples.Design_Patterns.Middleware;
using CodeSamples.Design_Patterns.Middleware.HusoMiddleware;
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
                .Build();

            var husoPipe = new HusoPipeBuilder(First) //First çalışan ana metot olucak. 
                .AddPipe(new HusoGlobalExceptionPipe() )
                .AddPipe(new HusoLoggerPipe() )
                .Build();

            Console.WriteLine("PipeBuilder PipeLine'ı çalıştırılıyor." + "\n" + "\n");
            pipe("Hello"); Console.WriteLine("\n");
            pipe("World"); Console.WriteLine("\n");
            pipe("This is Husoka!!!"); Console.WriteLine("\n");

            Console.WriteLine("HusoBuilder PipeLine'ı çalıştırılıyor." + "\n" + "\n");
            husoPipe("Hello"); Console.WriteLine("\n");
            husoPipe("World"); Console.WriteLine("\n");
            husoPipe("This is Husoka!!!"); Console.WriteLine("\n");
        }

        void First(string msg)
        {
            Console.WriteLine("The main/first method to invoke in the middleware: " + msg);
        }
    }
}
