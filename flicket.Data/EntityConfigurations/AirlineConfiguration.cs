using flicket.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flicket.Data.EntityConfigurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
