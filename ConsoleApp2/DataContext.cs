using ConsoleApp2.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2;

public class DataContext: DbContext
{
    public DbSet<Company> Companies { get; set; }

    public DbSet<Passenger> Passengers { get; set; }
    
    public DbSet<Trip> Trips { get; set; }
    
    public DbSet<PassInTrip> PassInTrips { get; set; }
    
    public DataContext()
    {
        Database.EnsureCreated();
        
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PassInTrip>().HasKey(x => new { x.IdPsg, x.TripNo, x.Date });
        
        modelBuilder.Entity<Company>()
            .HasMany(t => t.Trips)
            .WithOne(c => c.Company)
            .HasForeignKey(t => t.IdComp);
        
        modelBuilder.Entity<Passenger>()
            .HasMany(p => p.PassInTrips)
            .WithOne(p => p.Passenger)
            .HasForeignKey(p => p.IdPsg);
        
        modelBuilder.Entity<Trip>()
            .HasMany(p => p.PassInTrips)
            .WithOne(p => p.Trip)
            .HasForeignKey(p => p.TripNo);
        
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password;Database=otus");
        base.OnConfiguring(optionsBuilder);
    }
}