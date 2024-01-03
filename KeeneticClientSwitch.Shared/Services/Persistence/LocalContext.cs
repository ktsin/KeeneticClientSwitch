using KeeneticClientSwitch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KeeneticClientSwitch.Data.Services.Persistence;

public class LocalContext : DbContext
{
    private bool _isInitialized = false;

    public DbSet<LastLogin> LastLogins { get; set; }

    public LocalContext(DbContextOptions<LocalContext> options) : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LastLogin>().HasKey(x => x.Id);
        modelBuilder.Entity<LastLogin>().Property(x => x.Host).IsRequired();
        modelBuilder.Entity<LastLogin>().HasIndex(x => x.RecordedAt);
    }

    public virtual async Task Initialize()
    {
        if (_isInitialized)
            return;
        await Database.MigrateAsync();
        _isInitialized = true;
    }
}
