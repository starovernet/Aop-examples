using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommonProject;

namespace FodyExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var commonService = new CommonService();
            var decoratedService = new DecoratedService();

            sw.Start();
            decoratedService.Transfer(12,23,5);
            var t1 = sw.Elapsed;
            sw.Reset();
            sw.Start();
            commonService.Transfer(12,32,5);
            var t2 = sw.Elapsed;

            Console.WriteLine($"common - {t2.Milliseconds} ms, aspect - {t1.Milliseconds} ms");
            Console.WriteLine(decoratedService.ToString());
            Console.ReadKey();
        }
    }
}