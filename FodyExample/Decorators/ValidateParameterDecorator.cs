using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FodyExample.Decorators;

[module: ValidateParameterDecorator]
namespace FodyExample.Decorators
{
    class ValidateParameterDecorator:MethodDecoratorAttribute
    {
        private readonly List<Exception> _exceptions;

        public ValidateParameterDecorator()
        {
            _exceptions = new List<Exception>();
        }

        public override void Init(object instance, MethodBase method, object[] args)
        {
            var @params = method.GetParameters();
            for (var i = 0; i < args.Length; i++)
            {
                object argument = args[i];
                var number = argument as int?;
                if (number <= 0)
                    _exceptions.Add(new ArgumentOutOfRangeException(@params[i].Name));
            }
        }

        public override void OnEntry()
        {
            if (_exceptions.Any())
            throw new AggregateException(_exceptions);
        }

        public override void OnException(Exception exception)
        {
        }

        public override void OnExit()
        {
        }
    }
}
