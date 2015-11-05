using SimpleCQRS.Databases.Read;
using SimpleCQRS.Events;
using SimpleCQRS.ViewModels;

namespace SimpleCQRS.EventHandlers
{
    public class InventoryListView : Handles<InventoryItemCreated>, Handles<InventoryItemRenamed>, Handles<InventoryItemDeactivated>
    {
        public void Handle(InventoryItemCreated @event)
        {
            BullshitDatabase.List.Add(new InventoryItemListViewModel(@event.Id, @event.Name));
        }

        public void Handle(InventoryItemDeactivated @event)
        {
            BullshitDatabase.List.RemoveAll(x => x.Id == @event.Id);
        }

        public void Handle(InventoryItemRenamed @event)
        {
            var item = BullshitDatabase.List.Find(x => x.Id == @event.Id);

            item.Name = @event.NewName;
        }
    }
}
