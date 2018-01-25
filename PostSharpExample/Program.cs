using System;
using System.Diagnostics;
using CommonProject;

namespace PostSharpExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var commonService = new CommonService();
            var aspectService = new AspectService();
            var sw = new Stopwatch();
            sw.Start();
            commonService.Transfer(1, 2, 3);
            var t1 = sw.Elapsed;
            sw.Reset();
            sw.Start();
            aspectService.Transfer(1, 2, 3);
            var t2 = sw.Elapsed;
            sw.Stop();
            Console.WriteLine($"common - {t1.Milliseconds} ms, aspect - {t2.Milliseconds}");



            var data = new Data { CardNumber = "1234567890123456", OtherCardNumber = "0987654321" };
            Console.WriteLine(data.CardNumber + ", " + data.OtherCardNumber);
            Console.ReadKey();
        }
    }

}