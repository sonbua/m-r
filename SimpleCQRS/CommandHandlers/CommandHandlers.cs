using SimpleCQRS.Aggregate;
using SimpleCQRS.Commands;
using SimpleCQRS.Repository;

namespace SimpleCQRS.CommandHandlers
{
    public class InventoryCommandHandlers
    {
        private readonly IRepository<InventoryItem> _repository;

        public InventoryCommandHandlers(IRepository<InventoryItem> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateInventoryItemCommand command)
        {
            var item = new InventoryItem(command.InventoryItemId, command.Name);

            _repository.Save(item, -1);
        }

        public void Handle(DeactivateInventoryItemCommand command)
        {
            var item = _repository.GetById(command.InventoryItemId);

            item.Deactivate();

            _repository.Save(item, command.OriginalVersion);
        }

        public void Handle(RemoveItemsFromInventoryCommand command)
        {
            var item = _repository.GetById(command.InventoryItemId);

            item.Remove(command.Count);

            _repository.Save(item, command.OriginalVersion);
        }

        public void Handle(CheckInItemsToInventoryCommand command)
        {
            var item = _repository.GetById(command.InventoryItemId);

            item.CheckIn(command.Count);

            _repository.Save(item, command.OriginalVersion);
        }

        public void Handle(RenameInventoryItemCommand command)
        {
            var item = _repository.GetById(command.InventoryItemId);

            item.ChangeName(command.NewName);

            _repository.Save(item, command.OriginalVersion);
        }
    }
}
