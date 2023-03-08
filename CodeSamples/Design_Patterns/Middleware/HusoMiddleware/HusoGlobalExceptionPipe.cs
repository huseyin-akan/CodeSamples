using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware.HusoMiddleware
{
    public class HusoGlobalExceptionPipe : HusoPipe
    {        

        public HusoGlobalExceptionPipe() : base(null)
        {

        }

        public override void Handle(string msg)
        {
            try
            {
                Console.WriteLine("Handling all exceptions : " + msg);
                _action(msg);
                Console.WriteLine("Handled all exceptions : " + msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception handled : " + ex.Message);
            }

        }
    }
}
