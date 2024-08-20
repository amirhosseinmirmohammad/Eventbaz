using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventCore.Models;

namespace EventCore.Models.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Category)
                   .WithMany(c => c.Events)
                   .HasForeignKey(e => e.CatetoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Latitude)
                   .HasMaxLength(50);

            builder.Property(e => e.Longitude)
                   .HasMaxLength(50);

            builder.Property(e => e.Address)
                   .HasMaxLength(500);
        }
    }
}

