using System;
using System.Diagnostics;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace PostSharpExample.Aspects
{
    [PSerializable]
    public class LogParameters : BaseAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine(
                $"Entering {args.Method.DeclaringType?.Name}.{args.Method.Name}({ParameterInfos.Select((x, i) => $"{x.Name} = {args.Arguments[i]}").Aggregate((x, y) => x + ", " + y)})");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine($"Method {args.Method.Name} ended.");
        }
    }
}