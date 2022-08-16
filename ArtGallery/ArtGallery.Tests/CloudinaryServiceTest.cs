using ArtGallery.Core.Contracts;
using ArtGallery.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class CloudinaryServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<ICloudinaryService> _cloudinaryService;
        public CloudinaryServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _cloudinaryService = new Mock<ICloudinaryService>();
        }

        [Fact]
        public void UploadImageAsync_Test()
        {
            // Assert
            var content = "Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            _cloudinaryService.Setup(x => x.UploadImageAsync(file, fileName, null)).Returns("Test");

            // Verify
            _cloudinaryService.Verify(x => x.UploadImageAsync(file, fileName, null), Times.Never);
        }
    }
}
