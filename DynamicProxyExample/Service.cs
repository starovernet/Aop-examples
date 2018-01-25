using System;
using CommonProject;

namespace DynamicProxyExample
{
    public class Service
    {
        public virtual void Transfer(int sourceID, int destinationID, int size)
        {
            Storage source = Storage.GetById(sourceID);
            Storage destination = Storage.GetById(destinationID);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}