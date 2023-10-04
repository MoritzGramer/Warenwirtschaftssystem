using Microsoft.EntityFrameworkCore;
using Warenwirtschaftssystem;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Artikel> Artikel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artikel>()
            .HasKey(a => a.Artikelnummer); // Definiert die Artikelnummer als Primärschlüssel

        

        base.OnModelCreating(modelBuilder);
    }
}