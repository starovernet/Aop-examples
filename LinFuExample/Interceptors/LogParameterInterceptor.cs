using System;
using System.Linq;
using LinFu.DynamicProxy;

namespace LinFuExample.Interceptors
{
    internal class LogParameterInterceptor<T> : IInvokeWrapper
    {
        private readonly T _target;

        public LogParameterInterceptor(T target)
        {
            _target = target;
        }

        public void BeforeInvoke(InvocationInfo info)
        {
            Console.WriteLine(
                $"Arguments of method {info.TargetMethod.Name} ({string.Join(", ", info.TargetMethod.GetParameters().Select((x, i) => x.Name + ":" + info.Arguments[i]).ToArray())})");
        }

        public object DoInvoke(InvocationInfo info)
        {
            Console.WriteLine("I'm on do invoke");
            return info.TargetMethod.Invoke(_target, info.Arguments);
        }

        public void AfterInvoke(InvocationInfo info, object returnValue)
        {
            Console.WriteLine($"On out of method - {info.TargetMethod.Name}");
        }
    }
}