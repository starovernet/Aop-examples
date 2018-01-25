using LinFu.DynamicProxy;
using LinFuExample.Interceptors;

namespace LinFuExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyFactory = new ProxyFactory();
            var service = proxyFactory.CreateProxy<IService>(new LogParameterInterceptor<IService>(new Service()));
            service.Transfer(12, 32, 4);
        }
    }
}