using Flanimas___Backend.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Flanimas___Backend.Models;

namespace Flanimas___Backend.Models;

public class FlanimasContext : IdentityDbContext<User>
{
    public FlanimasContext(DbContextOptions<FlanimasContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Library>()
            .HasMany(e => e.Animes)
            .WithOne()
            .IsRequired();
        builder.Entity<Library>()
            .HasMany(e => e.Mangas)
            .WithOne()
            .IsRequired();
    }

public DbSet<Flanimas___Backend.Models.AnimeProgress> AnimeProgress { get; set; } = default!;

public DbSet<Flanimas___Backend.Models.MangaProgress> MangaProgress { get; set; } = default!;

public DbSet<Flanimas___Backend.Models.Library> Library { get; set; } = default!;
}
