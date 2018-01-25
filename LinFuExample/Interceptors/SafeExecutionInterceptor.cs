using System;
using LinFu.DynamicProxy;

namespace LinFuExample.Interceptors
{
    public class SafeExecutionInterceptor<T>:IInterceptor
    {
        private readonly T _target;
        public SafeExecutionInterceptor(T target)
        {
            _target = target;
        }
        public object Intercept(InvocationInfo info)
        {
            try
            {
                return info.TargetMethod.Invoke(_target, info.Arguments);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exceprion iccured in method {info.TargetMethod.Name}. Exception - {exception}");
            }
            return null;
        }
    }
}