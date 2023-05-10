using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware.HusoMiddleware
{
    public class HusoLoggerPipe : HusoPipe
    {
        public HusoLoggerPipe() : base(null)
        {

        }

        public override void Handle(string msg)
        {
            Console.WriteLine("Logged entrance by HusoLogger: " + msg);
            _action(msg);
            Console.WriteLine("Logged exit by HusoLogger: " + msg);
        }
    }
}
