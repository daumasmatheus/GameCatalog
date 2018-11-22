using GameCatalog.DAL.Context;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;

namespace GameCatalog.DAL.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        private readonly GameCatalogContext _context;

        public DeveloperRepository(GameCatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}