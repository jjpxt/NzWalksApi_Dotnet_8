using NzWalksApi_Dotnet_8.Models.Domain;

namespace NzWalksApi_Dotnet_8.Repositories;

public interface IImageRepository
{
    Task<Image> Upload(Image image);
}
