using Microsoft.EntityFrameworkCore;
using NzWalksApi_Dotnet_8.Models.Domain;

namespace NzWalksApi_Dotnet_8.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Difficulty> Difficulties{ get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("9ee976ef-e1fe-4f41-8913-107a64a1c0f3"),
                Name = "Eazy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("0ae912b6-3d6d-4b1f-809a-ea83701543cd"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("6e2596b0-866d-4cb8-a799-12eee0ac2c60"),
                Name = "Hard"
            }
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("1e2596b0-866d-4cb8-a799-12eee0ac2c61"),
                Name = "Auckland",
                Code = "AUK",
                RegionImageUrl = "auckland_image.jpg"
            },
            new Region
            {
                Id = Guid.Parse("1e2555b0-666d-4cb8-a449-12eee0ac2c61"),
                Name = "Wellington",
                Code = "WGL",
                RegionImageUrl = "welli.jpg"
            },
            new Region
            {
                Id = Guid.Parse("1e2000b0-866d-4cb9-a799-14eee0ac2c61"),
                Name = "Nelson",
                Code = "NSL",
                RegionImageUrl = "nelson_image.jpg"
            },
            new Region
            {
                Id = Guid.Parse("1e3456b0-866d-4cb9-a111-14eee0ac2c61"),
                Name = "Southland",
                Code = "STL",
                RegionImageUrl = null
            }
        };

        modelBuilder.Entity<Region>().HasData(regions);
    }
}
