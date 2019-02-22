using System.Linq;

namespace GroupBuilderApplication.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(int id);

        void Add(T entity);

        void Remove(T Entity);

    }
}