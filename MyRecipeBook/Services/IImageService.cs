using CloudinaryDotNet.Actions;

namespace MyRecipeBook.Services
{
    public interface IImageService
    {
        Task<ImageUploadResult> AddImageAsync(IFormFile formFile);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}
