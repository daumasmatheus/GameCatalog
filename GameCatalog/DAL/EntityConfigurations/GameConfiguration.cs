using GameCatalog.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameCatalog.DAL.EntityConfigurations
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            HasKey(g => g.Id);

            Property(g => g.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.Title).HasMaxLength(255).IsRequired();
            Property(g => g.Description).HasMaxLength(25555).IsRequired();
            Property(g => g.ReleaseDate).IsRequired();
        }
    }
}