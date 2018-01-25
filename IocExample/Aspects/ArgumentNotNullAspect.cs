using System;
using System.Linq;
using Castle.Core.Interceptor;

namespace IocExample.Aspects
{
    public class ArgumentNotNullAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var parameters = invocation.Method.GetParameters();
            var nullArgs = invocation.Arguments.Where(x => x == null).ToArray();
            for (int i = 0; i < nullArgs.Length; i++)
                Console.WriteLine($"Warning! Parameter {parameters[i].Name} is null");
            invocation.Proceed();
        }
    }
}