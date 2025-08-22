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

    public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null,
         string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
    {
        var walks = _nZWalksDbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

        if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }

        if (string.IsNullOrWhiteSpace(sortBy) == false)
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
            }
        }

        var skipResults = (pageNumber - 1) * pageSize;
        

        return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await _nZWalksDbContext.Walks
             .Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _nZWalksDbContext.Walks.AddRangeAsync(walk);
        await _nZWalksDbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        var existingWalk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk is null) return null;

        existingWalk.Name = walk.Name;
        existingWalk.Description = walk.Description;
        existingWalk.LengthInKm = walk.LengthInKm;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.DifficultyId = walk.DifficultyId;

        await _nZWalksDbContext.SaveChangesAsync();
        return existingWalk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var existingWalk = await _nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

        if (existingWalk == null)
            return null;

        _nZWalksDbContext.Walks.Remove(existingWalk);
        await _nZWalksDbContext.SaveChangesAsync();

        return existingWalk;
    }
}
