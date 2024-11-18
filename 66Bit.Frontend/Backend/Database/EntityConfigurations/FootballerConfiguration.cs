using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Database.EntityConfigurations;

public class FootballerConfiguration: IEntityTypeConfiguration<Footballer>
{
    public void Configure(EntityTypeBuilder<Footballer> builder)
    {
        builder.HasKey(f => f.Id);
        builder.ToTable("footballers");

        builder.Property(f => f.Name)
            .HasMaxLength(50);
        builder.Property(f => f.Surname)
            .HasMaxLength(50);
        builder.Property(f => f.Country)
            .HasMaxLength(50);
    }
}