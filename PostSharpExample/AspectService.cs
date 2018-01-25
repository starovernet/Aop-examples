using CommonProject;
using PostSharpExample.Aspects;

namespace PostSharpExample
{
    internal class AspectService
    {
        [ValidateParameters(false)]
        [SafeExecution]
        [LogParameters]
        public void Transfer(int sourceId, int destinationId, int size)
        {
            Storage source = Storage.GetById(sourceId);
            Storage destination = Storage.GetById(destinationId);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}