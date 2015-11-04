using System;

namespace SimpleCQRS.Commands
{
    public class RemoveItemsFromInventoryCommand : Command
    {
        public readonly int Count;
        public readonly int OriginalVersion;
        public Guid InventoryItemId;

        public RemoveItemsFromInventoryCommand(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}
