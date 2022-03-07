namespace ArtGallery.Services.Cloudinary.Contracts
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadImage(IFormFile file, string fileName);
    }
}
