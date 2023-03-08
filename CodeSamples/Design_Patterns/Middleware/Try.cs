using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware
{
    public class Try : Pipe
    {
        
        public Try(Action<string> action) : base(action)
        {

        }

        public override void Handle(string msg)
        {
            try
            {
                Console.WriteLine("Trying : " + msg);
                _action(msg);
                Console.WriteLine("Ending : " + msg);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
