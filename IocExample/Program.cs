using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using IocExample.Aspects;
using StructureMap;

namespace IocExample
{
    internal class Program
    {
        private static IContainer _container;

        public static void Main(string[] args)
        {
            Initialize();

            var sw = new Stopwatch();
            var proxyService = _container.GetInstance<IMyService>();
            var commonService = new MyService(new MyOtherService(new LoggingService()));

            sw.Start();
            proxyService.DoSomething();
            var t1 = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();
            commonService.DoSomething();
            var t2 = sw.ElapsedTicks;

            Console.WriteLine($"common - {t2} ticks, proxy - {t1} ticks");

            proxyService.Summation(5, 7);
            proxyService.Summation(null, null);
            Console.ReadKey();
        }

        private static void Initialize()
        {
            _container = new Container(x => x.Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
                var proxyGenerator = new ProxyGenerator();
                x.For<IMyService>()
                    .Use<MyService>()
                    .DecorateWith(svc =>
                        proxyGenerator.CreateInterfaceProxyWithTargetInterface(svc,
                            new LoggingAspect(new LoggingService()), new ArgumentNotNullAspect()));
            }));
        }
    }
}