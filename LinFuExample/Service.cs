using CommonProject;

namespace LinFuExample
{
    public class Service : IService
    {
        public void Transfer(int sourceId, int destinationId, int size)
        {
            Storage source = Storage.GetById(sourceId);
            Storage destination = Storage.GetById(destinationId);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}