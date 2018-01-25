namespace IocExample
{
    public  interface IMyService
    {
        void DoSomething();
        int? Summation(int? x, int? y);
    }

    public interface IMyOtherService
    {
        void DoSomethingElse();
    }

    public interface ILoggingService
    {
        void Log(string message);
    }
}