using System;
using Castle.Core.Interceptor;

namespace DynamicProxyExample.Interceptors
{
    public class ValidatorInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var parameterInfos = invocation.Method.GetParameters();
            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                object argument = invocation.Arguments[i];
                var number = argument as int?;
                if (number <= 0)
                {
                    throw new ArgumentOutOfRangeException(parameterInfos[i].Name);
                }
            }
            invocation.Proceed();
        }
    }
}