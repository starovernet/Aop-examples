using System;

namespace IocExample
{
    public  class MyOtherService:IMyOtherService
    {
        private readonly ILoggingService _log;

        public MyOtherService(ILoggingService log)
        {
            _log = log;
        }

        public void DoSomethingElse()
        {
            _log.Log("I am logger from my other service");
            Console.WriteLine("This is my other service! I do something else! :)");
        }
    }
}