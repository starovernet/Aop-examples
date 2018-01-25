using System.Reflection;
using CommonProject.Helpers;

namespace CommonProject
{
    public class CommonService
    {
        public void Transfer(int sourceId, int destinationId, int size)
        {
            Logger.LogParameters(MethodBase.GetCurrentMethod(),sourceId, destinationId, size);
            ArgumentChecker.CheckPositiveArguments(sourceId, destinationId, size);
            Executor.SafeExecution(() =>
            {
                Storage source = Storage.GetById(sourceId);
                Storage destination = Storage.GetById(destinationId);
                var values = source.GetValues(size);
                destination.PutValues(values);
            });
        }
    }
}