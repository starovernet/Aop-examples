using CommonProject;
using PostSharpExample.Aspects;

namespace PostSharpExample
{
    internal class AspectService
    {
        [ValidateParameters(false)]
        [SafeExecution]
        [LogParameters]
        public void Transfer(int sourceID, int destinationID, int size)
        {
            Storage source = Storage.GetById(sourceID);
            Storage destination = Storage.GetById(destinationID);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}