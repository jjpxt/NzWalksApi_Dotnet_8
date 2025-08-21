using NzWalksApi_Dotnet_8.Models.Domain;

namespace NzWalksApi_Dotnet_8.Repositories;

public interface IWalkRepository
{
    Task<List<Walk>> GetAllWalksAsync();
    Task<Walk> CreateAsync(Walk walk);
}
