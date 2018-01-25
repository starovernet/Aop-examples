using System;

namespace DynamicProxyExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var service = new Service();
            service.Transfer(12, 32, 15);

            var proxy = ServiceFactory.GetService(service);
            proxy.Transfer(12, 32, 15);
            Console.ReadKey();
        }

    }
}