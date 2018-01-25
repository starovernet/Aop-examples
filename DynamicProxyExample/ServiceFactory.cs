using Castle.DynamicProxy;
using DynamicProxyExample.Interceptors;

namespace DynamicProxyExample
{
    class ServiceFactory
    {
        private static readonly ProxyGenerator ProxyGenerator;

        static ServiceFactory()
        {
            ProxyGenerator = new ProxyGenerator();
        }

        public static Service GetService(Service obj)
        {
            return ProxyGenerator.CreateClassProxy<Service>(new LogParameterInterceptor(),
                new SafeExecutionInterceptor(), new ValidatorInterceptor());
        }
    }
}