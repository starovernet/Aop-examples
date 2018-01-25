using System;
using System.Linq;
using Castle.Core.Interceptor;

namespace DynamicProxyExample.Interceptors
{
    internal class LogParameterInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(
                $"Arguments of method {invocation.Method.Name} ({string.Join(", ", invocation.Method.GetParameters().Select((x, i) => x.Name + ":" + invocation.Arguments[i]).ToArray())})");
            invocation.Proceed();
            Console.WriteLine($"On out of method - {invocation.Method.Name}");
        }
    }
}