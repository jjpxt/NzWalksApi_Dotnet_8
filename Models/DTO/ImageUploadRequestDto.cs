using System.ComponentModel.DataAnnotations;

namespace NzWalksApi_Dotnet_8.Models.DTO;

public class ImageUploadRequestDto
{
    [Required]
    public IFormFile File { get; set; }
    [Required]
    public string FileName { get; set; }
    public string? FileDescription { get; set; }
}
