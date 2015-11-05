using SimpleCQRS.Events;

namespace SimpleCQRS.EventHandlers
{
    // ReSharper disable once InconsistentNaming
    public interface Handles<TEvent> where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}
