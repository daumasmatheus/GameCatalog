using GameCatalog.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameCatalog.DAL.EntityConfigurations
{
    public class GamePublisherConfiguration : EntityTypeConfiguration<GamePublisher>
    {
        public GamePublisherConfiguration()
        {
            HasKey(gp => gp.Id);

            Property(gp => gp.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(gp => gp.Name).HasMaxLength(255).IsRequired();
        }
    }
}