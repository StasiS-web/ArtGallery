namespace ArtGallery.Services.Cloudinary
{
    using System;
    using System.Threading.Tasks;
    using ArtGallery.Services.Cloudinary.Contracts;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
           this.cloudinary = cloudinary;
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile, string fileName)
        {
            byte[] data;
            var stream = new MemoryStream();

            using (stream)
            {
                await imageFile.CopyToAsync(stream);
                data = stream.ToArray();
            }

            UploadResult uploadResult = null;

            using (var message = new MemoryStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    Folder = "app_gallery",
                    File = new FileDescription(fileName, message),
                    Transformation = new Transformation().Height(300).Width(300).Crop("fit"),
                };

                uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
