using System;

namespace SimpleCQRS.Commands
{
    public class DeactivateInventoryItemCommand : Command
    {
        public readonly Guid InventoryItemId;
        public readonly int OriginalVersion;

        public DeactivateInventoryItemCommand(Guid inventoryItemId, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            OriginalVersion = originalVersion;
        }
    }
}
