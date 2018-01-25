using System;
using Castle.Core.Interceptor;

namespace DynamicProxyExample.Interceptors
{
    public class SafeExecutionInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exceprion iccured in method {invocation.Method.Name}. Exception - {e}");
            }
        }
    }
}