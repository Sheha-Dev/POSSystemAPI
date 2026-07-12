using POS_System_Web_API.Models.Entities;
using POSSystemWebAPI.Models;
using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Interfaces
{

    public interface IUserLocationService
    {
        Task<List<LocationDetail>> GetAllAsync();
        Task SaveAsync(IEnumerable<LocationDto> locations);
    }
}