using CarDealership.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using MimeDetective;

namespace CarDealership.Application.Validators
{
    public class ImageValidator : IImageValidator
    {
        public async Task<bool> IsValidJpegFile(IFormFile file)
        {
            if (!file.FileName.Contains(".jpg") && !file.FileName.Contains(".jpeg"))
            {
                return false;
            }

            var buffer = new byte[512];

            await using (var stream = file.OpenReadStream())
            {
                stream.Read(buffer, 0, buffer.Length);

                var inspector = new ContentInspectorBuilder
                {
                    Definitions = MimeDetective.Definitions.Default.All()
                }.Build();

                var results = inspector.Inspect(buffer);
                var jpegMatches = results.ByMimeType();
                return jpegMatches.Any(x => x.MimeType == "image/jpeg")
                       || jpegMatches.Any(x => x.MimeType == "image/jpg");
            }
        }
    }
}
