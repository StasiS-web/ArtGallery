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

        public async Task<string> UploadImageAsync(IFormFile file, string fileName, int heigth, int width)
        {
            byte[] data;
            var stream = new MemoryStream();

            using (stream)
            {
                await file.CopyToAsync(stream);
                data = stream.ToArray();
            }

            UploadResult uploadResult = null;

            using (var message = new MemoryStream(data))
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    Folder = "app_gallery",
                    File = new FileDescription(fileName, message),
                    Transformation = new Transformation().Height(heigth).Width(width).Crop("fit"),
                };

                uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult?.SecureUrl.AbsoluteUri;
        }
    }
}
