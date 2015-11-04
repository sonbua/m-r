using System;

namespace SimpleCQRS.Commands
{
    public class RenameInventoryItemCommand : Command
    {
        public readonly Guid InventoryItemId;
        public readonly string NewName;
        public readonly int OriginalVersion;

        public RenameInventoryItemCommand(Guid inventoryItemId, string newName, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            NewName = newName;
            OriginalVersion = originalVersion;
        }
    }
}
