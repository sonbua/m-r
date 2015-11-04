using System;

namespace SimpleCQRS.Commands
{
    public class CheckInItemsToInventoryCommand : Command
    {
        public readonly int Count;
        public readonly int OriginalVersion;
        public Guid InventoryItemId;

        public CheckInItemsToInventoryCommand(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}
