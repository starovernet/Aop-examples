using System;
using System.Linq;
using System.Reflection;
using FodyExample.Decorators;

[module: LogDecorator]

namespace FodyExample.Decorators
{
    public class LogDecoratorAttribute : MethodDecoratorAttribute
    {
        private ParameterInfo[] _params;
        private object[] _args;
        private bool _wasException;
        private MethodBase _method;

        public override void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;
            _args = args;
            _params = method.GetParameters();
        }

        public override void OnEntry()
        {
            Console.WriteLine(
                $"Parameters of method {_method.Name} ({string.Join(", ", _params.Select((x, i) => x.Name + ":" + _args[i]))})");
        }

        public override void OnException(Exception exception)
        {
            _wasException = true;
            Console.WriteLine($"OnException: {exception.GetType()}: {exception.Message}");
        }

        public override void OnExit()
        {
            if (!_wasException)
            {
                Console.WriteLine("The method " + _method.Name +
                                  " successfully ended. Return value cannot access from fody");
            }
        }
    }
}