using System;
using System.Collections.Generic;
using SimpleCQRS.Dto;

namespace SimpleCQRS.Facade
{
    public interface IReadModelFacade
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();

        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
    }
}