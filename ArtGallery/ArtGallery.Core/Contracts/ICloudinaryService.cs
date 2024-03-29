﻿namespace ArtGallery.Core.Contracts
{
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        string UploadImageAsync(IFormFile file, string fileName, Transformation transformation = null);
    }
}
