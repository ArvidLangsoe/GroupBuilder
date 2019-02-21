using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupBuilderPersistence.Shared
{
    public class Repository<T>
        : IRepository<T>
        where T : class, IEntity

    {
        private readonly DatabaseContext _database;

        public Repository(DatabaseContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(int id)
        {
            return _database.Set<T>()
                .SingleOrDefault(p => p.Id == id);
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }

    }
}
