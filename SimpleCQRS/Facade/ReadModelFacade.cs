using System;
using System.Collections.Generic;
using SimpleCQRS.Database;
using SimpleCQRS.Dto;

namespace SimpleCQRS.Facade
{
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return BullshitDatabase.List;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return BullshitDatabase.Details[id];
        }
    }
}
