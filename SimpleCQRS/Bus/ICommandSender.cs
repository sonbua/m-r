using SimpleCQRS.Commands;

namespace SimpleCQRS.Bus
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}
