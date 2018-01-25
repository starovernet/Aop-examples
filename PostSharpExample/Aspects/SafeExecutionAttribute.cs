using System;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace PostSharpExample.Aspects
{
    [PSerializable]
    internal class SafeExecutionAttribute : BaseAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine(
                $"Exception: {args.Method.DeclaringType?.Name}.{args.Method.Name}({ParameterInfos.Select((x, i) => $"{x.Name} = {args.Arguments[i]}").Aggregate((x, y) => x + ", " + y)})");
            args.FlowBehavior = FlowBehavior.ThrowException;
        }
    }
}