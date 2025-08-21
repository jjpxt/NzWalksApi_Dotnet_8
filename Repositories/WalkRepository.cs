using Microsoft.EntityFrameworkCore;
using NzWalksApi_Dotnet_8.Data;
using NzWalksApi_Dotnet_8.Models.Domain;

namespace NzWalksApi_Dotnet_8.Repositories;

public class WalkRepository : IWalkRepository
{
    private readonly NZWalksDbContext _nZWalksDbContext;

    public WalkRepository(NZWalksDbContext nZWalksDbContext)
    {
        _nZWalksDbContext = nZWalksDbContext;
    }

    public async Task<List<Walk>> GetAllWalksAsync()
    {
        return await _nZWalksDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _nZWalksDbContext.Walks.AddRangeAsync(walk);
        await _nZWalksDbContext.SaveChangesAsync();
        return walk;
    }

}
