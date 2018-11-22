using GameCatalog.DAL.Context;
using GameCatalog.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace GameCatalog.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GameCatalogContext _context;

        public GenericRepository(GameCatalogContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}