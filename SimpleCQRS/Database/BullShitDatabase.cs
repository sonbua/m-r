using System;
using System.Collections.Generic;
using SimpleCQRS.Dto;

namespace SimpleCQRS.Database
{
    public static class BullshitDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> Details = new Dictionary<Guid, InventoryItemDetailsDto>();

        public static List<InventoryItemListDto> List = new List<InventoryItemListDto>();
    }
}
