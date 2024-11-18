using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Database.EntityConfigurations;

public class TeamConfiguration: IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable("teams");

        builder.Property(t => t.Name)
            .HasMaxLength(100);

        builder.HasMany(t => t.Footballers)
            .WithOne(f => f.Team);
    }
}