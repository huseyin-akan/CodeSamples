using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware
{
    public class Wrap : Pipe
    {
        public Wrap(Action<string> action) : base(action)
        {

        }

        public override void Handle(string msg)
        {
            Console.WriteLine("Starting: " + msg);
            _action(msg);
            Console.WriteLine("Ending: " + msg);
        }
    }
}
