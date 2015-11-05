using System;
using System.Collections.Generic;
using SimpleCQRS.Databases.Read;
using SimpleCQRS.ViewModels;

namespace SimpleCQRS.ViewModelFacade
{
    public class ViewModelFacade : IViewModelFacade
    {
        public IEnumerable<InventoryItemListViewModel> GetInventoryItems()
        {
            return BullshitDatabase.List;
        }

        public InventoryItemDetailsViewModel GetInventoryItemDetails(Guid id)
        {
            return BullshitDatabase.Details[id];
        }
    }
}
