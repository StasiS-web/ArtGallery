namespace ArtGallery.Services.Cloudinary
{
    using System;
    using System.Threading.Tasks;
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

        public async Task<string> UploadImageAsync(IFormFile imageFile, string fileName, int height, int width)
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
                };

                uploadResult = this.cloudinary.Upload(uploadParams);
            }

            return this.cloudinary.Api.UrlImgUp.Transform(new Transformation().Height(height).Width(width).Crop("fit"))
                 .BuildImageTag(string.Format("{0}", uploadResult.Format));
        }
    }
}
