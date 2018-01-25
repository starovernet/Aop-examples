using System;
using System.Reflection;

namespace FodyExample.Decorators
{
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public abstract class MethodDecoratorAttribute : Attribute
    {
        public abstract void Init(object instance, MethodBase method, object[] args);
        public abstract void OnEntry();
        public abstract void OnException(Exception exception);
        public abstract void OnExit();
    }
}