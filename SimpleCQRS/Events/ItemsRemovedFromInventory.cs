using System;

namespace SimpleCQRS.Events
{
    public class ItemsRemovedFromInventory : Event
    {
        public readonly int Count;
        public Guid Id;

        public ItemsRemovedFromInventory(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
