using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Services.Abstract;

namespace Smbs.Application.Services.Concrete;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<(string? Url, string? PublicId, string? Error)> UploadImageAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            return (null, null, "The file is empty");

        using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, stream),
            Folder = folderName 
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        if (uploadResult.Error != null)
            return (null, null, uploadResult.Error.Message);

        return (uploadResult.SecureUrl.ToString(), uploadResult.PublicId, null);
    }

    //public async Task<bool> DeleteImageAsync(string imageUrl)
    //{
    //    if (string.IsNullOrEmpty(imageUrl)) return false;

    //    try
    //    {
    //        // URL nümunəsi: https://cloudinary.com
    //        var uri = new Uri(imageUrl);
    //        var segments = uri.Segments;

    //        var folderAndFile = string.Join("", segments.Skip(segments.Length - 2));

    //        var publicId = Path.ChangeExtension(folderAndFile, null);

    //        var deletionParams = new DeletionParams(publicId);
    //        var result = await _cloudinary.DestroyAsync(deletionParams);

    //        return result.Result == "ok";
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    public async Task<bool> DeleteImageAsync(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl)) return false;

        try
        {
            var publicId = GetPublicIdFromUrl(imageUrl);
            var deletionParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deletionParams);

            return result.Result == "ok";
        }
        catch
        {
            return false;
        }
    }
    public async Task<(string? Url, string? PublicId, string? Error)> UploadVideoAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            return (null, null, "The file is empty");

        using var stream = file.OpenReadStream();
        var uploadParams = new VideoUploadParams() 
        {
            File = new FileDescription(file.FileName, stream),
            Folder = folderName
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        if (uploadResult.Error != null)
            return (null, null, uploadResult.Error.Message);

        return (uploadResult.SecureUrl.ToString(), uploadResult.PublicId, null);
    }

    public async Task<bool> DeleteVideoAsync(string videoUrl)
    {
        if (string.IsNullOrEmpty(videoUrl)) return false;

        try
        {
            var publicId = GetPublicIdFromUrl(videoUrl); 

            var deletionParams = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Video 
            };

            var result = await _cloudinary.DestroyAsync(deletionParams);
            return result.Result == "ok";
        }
        catch
        {
            return false;
        }
    }

    private string GetPublicIdFromUrl(string url)
    {
        var uri = new Uri(url);
        var segments = uri.Segments;

        var versionIndex = Array.FindIndex(segments, s => s.StartsWith("v") && s.Length > 1 && char.IsDigit(s[1]));

        string folderAndFile;
        if (versionIndex != -1 && versionIndex < segments.Length - 1)
        {
            folderAndFile = string.Join("", segments.Skip(versionIndex + 1));
        }
        else
        {
            folderAndFile = string.Join("", segments.Skip(segments.Length - 2));
        }

        return Path.ChangeExtension(folderAndFile, null).Trim('/');
    }
}
