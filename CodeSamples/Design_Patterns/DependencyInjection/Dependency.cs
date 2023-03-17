using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.DependencyInjection
{
    public class Dependency
    {
        public Dependency(Type t, DependencyLifetime l)
        {
            Type = t;
            Lifetime = l;
        }
        public Type Type { get; set; }
        public DependencyLifetime Lifetime { get; set; }
        public object Implementation { get; set; }
        public bool Implemented { get; set; }

        public void AddImplementation(object i)
        {
            Implementation = i;
            Implemented = true;
        }
    }
}
