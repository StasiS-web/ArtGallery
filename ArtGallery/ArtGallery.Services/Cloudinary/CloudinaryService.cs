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

        public string UploadImageAsync(IFormFile imageFile, string file)
        {
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
                    // Transformation = new Transformation().Height(300).Width(300).Crop("fit"),
                    PublicId = file,
                };

                uploadResult = this.cloudinary.Upload(uploadParams);
           }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
