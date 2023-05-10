﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware
{
    public abstract class Pipe
    {
        protected Action<string> _action;
        public Pipe(Action<string> action)
        {
            _action = action;
        }

        public abstract void Handle(string msg);
    }
}
