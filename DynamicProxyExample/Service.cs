using CommonProject;

namespace DynamicProxyExample
{
    public class Service
    {
        public virtual void Transfer(int sourceId, int destinationId, int size)
        {
            Storage source = Storage.GetById(sourceId);
            Storage destination = Storage.GetById(destinationId);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}