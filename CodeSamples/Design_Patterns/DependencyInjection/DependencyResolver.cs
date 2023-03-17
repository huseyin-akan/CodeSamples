using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.DependencyInjection
{
    public class DependencyResolver
    {
        DependencyContainer _container;
        public DependencyResolver(DependencyContainer container)
        {
            _container = container;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            var dependency = _container.GetDependency(type);
            var constructor = dependency.Type.GetConstructors().Single();
            var parameters = constructor.GetParameters().ToArray();

            if (parameters.Length > 0)
            {
                var parameterImplementations = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterImplementations[i] = GetService(parameters[i].ParameterType);
                }

                return CreateImplementaiton(dependency, t => Activator.CreateInstance(t, parameterImplementations));
            }

            return CreateImplementaiton(dependency, t => Activator.CreateInstance(t));
        }

        public object CreateImplementaiton(Dependency dependency, Func<Type, object> factory)
        {
            if (dependency.Implemented)
            {
                return dependency.Implementation;
            }

            var implementation = factory(dependency.Type);

            if (dependency.Lifetime == DependencyLifetime.Singleton)
            {
                dependency.AddImplementation(implementation);
            }

            return implementation;
        }
    }
}
