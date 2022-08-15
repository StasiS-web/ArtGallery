namespace ArtGallery.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using ArtGallery.Core.Contracts;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
           this._cloudinary = cloudinary;
        }

        public string UploadImageAsync(IFormFile imageFile, string file, Transformation transformation = null)
        {
            imageFile = imageFile ?? throw new ArgumentNullException(nameof(imageFile));

            byte[] data;
            var stream = new MemoryStream();

            using (stream)
            {
                imageFile.CopyToAsync(stream);
                data = stream.ToArray();
            }

            UploadResult uploadResult = null;

           using (var message = new MemoryStream(data))
           {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    Folder = "app_gallery",
                    File = new FileDescription(file, message),
                    Transformation = transformation,
                    PublicId = file,
                };

                uploadResult = this._cloudinary.Upload(uploadParams);
           }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
