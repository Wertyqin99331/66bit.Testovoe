using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Database;

public class AppDbContext(IConfiguration configuration): DbContext
{
    public DbSet<Footballer> Footballers { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var connectionString = configuration.GetConnectionString("Postgres");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<Team>()
            .HasData(new Team(Guid.NewGuid(), "Барселона"), new Team(Guid.NewGuid(), "Реал Мадрид"));
    } 
}