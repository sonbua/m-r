using System;
using System.Collections.Generic;
using SimpleCQRS.Events;

namespace SimpleCQRS.Aggregate
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> _changes = new List<Event>();

        public abstract Guid Id { get; }

        public int Version { get; internal set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var @event in history)
            {
                Apply(@event);
            }
        }

        protected void ApplyChange(Event @event)
        {
            Apply(@event);

            _changes.Add(@event);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void Apply(Event @event)
        {
            this.AsDynamic().Apply(@event);
        }
    }
}
