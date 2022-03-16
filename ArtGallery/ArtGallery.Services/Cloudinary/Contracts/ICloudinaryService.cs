namespace ArtGallery.Services.Cloudinary.Contracts
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        string UploadImageAsync(IFormFile file, string fileName);
    }
}
