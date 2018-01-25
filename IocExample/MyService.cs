using System;

namespace IocExample
{
    public class MyService : IMyService
    {
        private readonly IMyOtherService _otherService;

        public MyService(IMyOtherService otherService)
        {
            _otherService = otherService;
        }

        public void DoSomething()
        {
            Console.WriteLine("This is My service! I am very helpful!");
            _otherService.DoSomethingElse();
        }

        public int? Summation(int? x, int? y)
        {
            return x + y;
        }
    }
}