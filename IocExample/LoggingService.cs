using System;

namespace IocExample
{
    public  class LoggingService:ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging - " + message);
        }
    }
}