using System;
using SimpleCQRS.Database;
using SimpleCQRS.Dto;
using SimpleCQRS.Events;

namespace SimpleCQRS.Handles
{
    public class InventoryItemDetailView : Handles<InventoryItemCreated>, Handles<InventoryItemDeactivated>, Handles<InventoryItemRenamed>, Handles<ItemsRemovedFromInventory>, Handles<ItemsCheckedInToInventory>
    {
        public void Handle(InventoryItemCreated @event)
        {
            BullshitDatabase.Details.Add(@event.Id, new InventoryItemDetailsDto(@event.Id, @event.Name, 0, 0));
        }

        public void Handle(InventoryItemDeactivated @event)
        {
            BullshitDatabase.Details.Remove(@event.Id);
        }

        public void Handle(InventoryItemRenamed @event)
        {
            var details = GetDetailsItem(@event.Id);

            details.Name = @event.NewName;
            details.Version = @event.Version;
        }

        public void Handle(ItemsCheckedInToInventory @event)
        {
            var details = GetDetailsItem(@event.Id);

            details.CurrentCount += @event.Count;
            details.Version = @event.Version;
        }

        public void Handle(ItemsRemovedFromInventory @event)
        {
            var details = GetDetailsItem(@event.Id);

            details.CurrentCount -= @event.Count;
            details.Version = @event.Version;
        }

        private InventoryItemDetailsDto GetDetailsItem(Guid id)
        {
            InventoryItemDetailsDto details;

            if (BullshitDatabase.Details.TryGetValue(id, out details))
            {
                return details;
            }

            throw new InvalidOperationException("did not find the original inventory this shouldnt happen");
        }
    }
}
