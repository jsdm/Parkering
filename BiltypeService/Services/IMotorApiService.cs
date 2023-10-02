using BiltypeService.Models;

namespace BiltypeService.Services
{
    public interface IMotorApiService
    {
        Task<CarDescription> GetDescriptionAsync(string licensePlate);
    }
}