using SimpleCQRS.Events;

namespace SimpleCQRS.Bus
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
