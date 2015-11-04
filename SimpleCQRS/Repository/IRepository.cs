using System;
using SimpleCQRS.Aggregate;

namespace SimpleCQRS.Repository
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);

        TEntity GetById(Guid id);
    }
}
