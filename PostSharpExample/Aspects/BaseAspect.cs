using System;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace PostSharpExample.Aspects
{
    [PSerializable]
    public class BaseAspect:OnMethodBoundaryAspect
    {
        protected ParameterInfo[] ParameterInfos;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            ParameterInfos = method.GetParameters();
        }
    }
}
