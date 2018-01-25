using Castle.Core.Interceptor;

namespace IocExample.Aspects
{
    public class LoggingAspect : IInterceptor
    {
        private readonly ILoggingService _logger;

        public LoggingAspect(ILoggingService logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Log(invocation.Method.Name + " Start");
            invocation.Proceed();
            _logger.Log(invocation.Method.Name + " End.");
            if (invocation.Method.ReturnType != typeof(void))
                _logger.Log(" Reurn value - " + (invocation.ReturnValue?.ToString() ?? "null"));
        }
    }
}