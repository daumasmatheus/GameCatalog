using GameCatalog.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameCatalog.DAL.EntityConfigurations
{
    public class DeveloperConfiguration : EntityTypeConfiguration<Developer>
    {
        public DeveloperConfiguration()
        {
            HasKey(d => d.Id);

            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.Name).HasMaxLength(255).IsRequired();
        }
    }
}