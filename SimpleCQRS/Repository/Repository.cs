using System;
using SimpleCQRS.Aggregate;
using SimpleCQRS.Databases.Write;

namespace SimpleCQRS.Repository
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            var obj = new T(); //lots of ways to do this
            var events = _storage.GetEventsForAggregate(id);

            obj.LoadsFromHistory(events);

            return obj;
        }
    }
}
