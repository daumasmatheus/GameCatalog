using GameCatalog.DAL.EntityConfigurations;
using GameCatalog.Entities;
using System.Data.Entity;

namespace GameCatalog.DAL.Context
{
    public class GameCatalogContext : DbContext
    {
        public GameCatalogContext() : base("defaultConnection")
        {

        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePublisher> GamePublishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeveloperConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new GamePublisherConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}