using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _database;

        public UnitOfWork(DatabaseContext database) {
            _database = database;
        }

        public void Save()
        {
            _database.Save();
        }
    }
}
