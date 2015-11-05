using System;
using System.Collections.Generic;
using SimpleCQRS.ViewModels;

namespace SimpleCQRS.ViewModelFacade
{
    public interface IViewModelFacade
    {
        IEnumerable<InventoryItemListViewModel> GetInventoryItems();

        InventoryItemDetailsViewModel GetInventoryItemDetails(Guid id);
    }
}
