using System;

namespace SimpleCQRS.ViewModels
{
    public class InventoryItemListViewModel
    {
        public Guid Id;
        public string Name;

        public InventoryItemListViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
