using System;

namespace CommonProject
{
    public class Storage
    {
        public int Id { get; set; }
        public static Storage GetById(int sourceId)
        {
            return new Storage {Id = sourceId};
        }

        public void PutValues(object values)
        {
            Console.WriteLine($"Putting data into Storage {Id}");
        }

        public object GetValues(int size)
        {
            Console.WriteLine($"Getting data from storage {Id}");
            return new object();
        }
    }
}