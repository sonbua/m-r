using SimpleCQRS.Database;
using SimpleCQRS.Dto;
using SimpleCQRS.Events;

namespace SimpleCQRS.Handles
{
    public class InventoryListView : Handles<InventoryItemCreated>, Handles<InventoryItemRenamed>, Handles<InventoryItemDeactivated>
    {
        public void Handle(InventoryItemCreated @event)
        {
            BullshitDatabase.List.Add(new InventoryItemListDto(@event.Id, @event.Name));
        }

        public void Handle(InventoryItemRenamed @event)
        {
            var item = BullshitDatabase.List.Find(x => x.Id == @event.Id);

            item.Name = @event.NewName;
        }

        public void Handle(InventoryItemDeactivated @event)
        {
            BullshitDatabase.List.RemoveAll(x => x.Id == @event.Id);
        }
    }
}