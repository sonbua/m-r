using System;

namespace SimpleCQRS.Events
{
    public class ItemsCheckedInToInventory : Event
    {
        public readonly int Count;
        public Guid Id;

        public ItemsCheckedInToInventory(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
