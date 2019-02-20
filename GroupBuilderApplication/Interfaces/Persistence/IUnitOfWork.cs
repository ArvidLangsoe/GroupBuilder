using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
