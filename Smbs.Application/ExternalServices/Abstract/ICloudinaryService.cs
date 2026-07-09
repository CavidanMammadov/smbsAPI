using Microsoft.AspNetCore.Http;

namespace Smbs.Application.Services.Abstract;

public interface ICloudinaryService
{
    Task<(string? Url, string? PublicId, string? Error)> UploadImageAsync(IFormFile file, string folderName);
    Task<bool> DeleteImageAsync(string imageUrl);
    Task<(string? Url, string? PublicId, string? Error)> UploadVideoAsync(IFormFile file, string folderName);
    Task<bool> DeleteVideoAsync(string videoUrl);
}