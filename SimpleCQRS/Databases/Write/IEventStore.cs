using System;
using System.Collections.Generic;
using SimpleCQRS.Events;

namespace SimpleCQRS.Databases.Write
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);

        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}
