using CommonProject;

namespace LinFuExample
{
    public class Service : IService
    {
        public void Transfer(int sourceID, int destinationID, int size)
        {
            Storage source = Storage.GetById(sourceID);
            Storage destination = Storage.GetById(destinationID);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}