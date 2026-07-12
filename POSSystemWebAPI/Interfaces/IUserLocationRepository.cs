using POS_System_Web_API.Models.Entities;
using POSSystemWebAPI.Models;

namespace POSSystemWebAPI.Interfaces
{
    public interface IUserLocationRepository
    {
        Task<List<LocationDetail>> GetAllAsync();
        Task UpsertRangeAsync(IEnumerable<LocationDetail> locations);
    }
}
