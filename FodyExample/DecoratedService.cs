using System;
using CommonProject;
using FodyExample.Decorators;

namespace FodyExample
{
    [ToString]
    public class DecoratedService
    {
        [IgnoreDuringToString]
        private int NonVisible => 4;
        public int Id => 5;
        public DateTime Now => DateTime.Now;
        [LogDecorator]
        [ValidateParameterDecorator]
        public void Transfer(int sourceID, int destinationID, int size)
        {
            Storage source = Storage.GetById(sourceID);
            Storage destination = Storage.GetById(destinationID);

            var values = source.GetValues(size);
            destination.PutValues(values);
        }
    }
}