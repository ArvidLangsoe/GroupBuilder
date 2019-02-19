using GroupBuilderDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence.Shared
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
