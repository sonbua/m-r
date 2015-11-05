using System;

namespace SimpleCQRS.ViewModels
{
    public class InventoryItemDetailsViewModel
    {
        public Guid Id;
        public string Name;
        public int CurrentCount;
        public int Version;

        public InventoryItemDetailsViewModel(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }
    }
}
