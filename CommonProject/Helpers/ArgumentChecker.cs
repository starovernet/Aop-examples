using System;
using System.Reflection;

namespace CommonProject.Helpers
{
    internal class ArgumentChecker
    {
        public static void CheckPositiveArguments(params int[] args)
        {
            var parameters = MethodBase.GetCurrentMethod().GetParameters();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] < 0)
                    throw new ArgumentException(parameters[i].Name);
            }
        }
    }
}