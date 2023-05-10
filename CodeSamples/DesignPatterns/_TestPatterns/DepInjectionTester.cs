using CodeSamples.Design_Patterns.DependencyInjection;
using CodeSamples.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns._TestPatterns
{
    public class DepInjectionTester : ITester
    {
        public void Test()
        {
            var container = new DependencyContainer();
            container.AddTransient<ServiceConsumer>();
            container.AddTransient<HelloService>();
            container.AddSingleton<MessageService>();

            var resolver = new DependencyResolver(container);

            var service1 = resolver.GetService<ServiceConsumer>();

            service1.Print();
            var service2 = resolver.GetService<ServiceConsumer>();
            service2.Print();
            var service3 = resolver.GetService<ServiceConsumer>();
            service3.Print();
        }
    }

    public class ServiceConsumer
    {
        HelloService _hello;
        public ServiceConsumer(HelloService hello)
        {
            _hello = hello;
        }

        public void Print()
        {
            _hello.Print();
        }
    }

    public class HelloService
    {
        MessageService _message;
        int _random;
        public HelloService(MessageService message)
        {
            _message = message;
            _random = new Random().Next();
        }

        public void Print()
        {
            Console.WriteLine($"Hello World {_message.Message()}");
        }
    }

    public class MessageService
    {
        int _random;
        public MessageService()
        {
            _random = new Random().Next();
        }

        public string Message()
        {
            return $"Yo #{_random}";
        }
    }
}
