using System;
using System.Linq;
using System.Reflection;

namespace CommonProject.Helpers
{
    internal class Logger
    {
        public static void LogParameters(MethodBase callerMethod, params object[] args)
        {
            Console.WriteLine(
                $"Entering {callerMethod.Name} ({callerMethod.GetParameters().Select((x, i) => x.Name + " : " + args[i]).Aggregate((x, y) => x + ", " + y)})");
        }
    }
}