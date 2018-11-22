using GameCatalog.DAL.Context;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;

namespace GameCatalog.DAL.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly GameCatalogContext _context;

        public GameRepository(GameCatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}