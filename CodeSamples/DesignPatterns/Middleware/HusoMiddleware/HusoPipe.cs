using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware.HusoMiddleware
{
    public abstract class HusoPipe
    {
        public Action<string> _action;  //Action burda string parametresi alan ve void olan bir metot ama istediğin tiple çalış. Nasıl istiyorsan.
        public HusoPipe(Action<string> action)
        {
            _action = action;
        }

        public abstract void Handle(string msg);
    }
}
