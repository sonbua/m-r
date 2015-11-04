using SimpleCQRS.Events;

namespace SimpleCQRS.Handles
{
    public interface Handles<TEvent> where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}
