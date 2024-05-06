using Microsoft.AspNetCore.Http;

namespace CarDealership.Application.Abstractions
{
    public interface IImageValidator
    {
        Task<bool> IsValidJpegFile(IFormFile file);
    }
}
