using System.Linq;

namespace GameCatalog.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
        IQueryable<T> Get();
        T Find(int id);
        void Edit(T entity);
        void SaveChanges();
    }
}
