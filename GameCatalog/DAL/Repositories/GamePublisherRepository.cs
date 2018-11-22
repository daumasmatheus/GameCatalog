using GameCatalog.DAL.Context;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;

namespace GameCatalog.DAL.Repositories
{
    public class GamePublisherRepository : GenericRepository<GamePublisher>, IGamePublisherRepository
    {
        private readonly GameCatalogContext _context;

        public GamePublisherRepository(GameCatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}