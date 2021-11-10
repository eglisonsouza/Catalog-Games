using CatalogGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogGames.Infra.Persistence.EF.Map
{
    public class MapGame: IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Producer).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).IsRequired();
        }
    }
}