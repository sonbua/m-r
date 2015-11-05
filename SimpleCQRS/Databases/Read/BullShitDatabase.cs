using System;
using System.Collections.Generic;
using SimpleCQRS.ViewModels;

namespace SimpleCQRS.Databases.Read
{
    public static class BullshitDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsViewModel> Details = new Dictionary<Guid, InventoryItemDetailsViewModel>();

        public static List<InventoryItemListViewModel> List = new List<InventoryItemListViewModel>();
    }
}
