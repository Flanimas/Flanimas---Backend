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
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<Flanimas___Backend.Models.AnimeProgress> AnimeProgress { get; set; } = default!;

public DbSet<Flanimas___Backend.Models.MangaProgress> MangaProgress { get; set; } = default!;
}
