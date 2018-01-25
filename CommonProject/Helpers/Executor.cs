using System;
using System.Reflection;

namespace CommonProject.Helpers
{
    internal class Executor
    {
        public static void SafeExecution(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                var method = MethodBase.GetCurrentMethod();
                Console.WriteLine($"Exception on method {method.Name} : {e}");
            }
        }
    }
}