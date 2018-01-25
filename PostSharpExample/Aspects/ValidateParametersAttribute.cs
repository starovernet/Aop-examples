using System;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace PostSharpExample.Aspects
{
    [PSerializable]
    internal class ValidateParametersAttribute : BaseAspect
    {
        private bool _checkLessThenZero;

        public ValidateParametersAttribute(bool checkLessThenZero)
        {
            _checkLessThenZero = checkLessThenZero;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            for (var i = 0; i < args.Arguments.Count; i++)
            {
                if (_checkLessThenZero)
                    if (args.Arguments[i] is int)
                    {
                        if (((int) args.Arguments[i]) < 0)
                            throw new Exception("");
                    }
                object argument = args.Arguments[i];
                var number = argument as int?;
                if (number <= 0)
                    throw new ArgumentOutOfRangeException(ParameterInfos[i].Name);
            }
        }
    }
}