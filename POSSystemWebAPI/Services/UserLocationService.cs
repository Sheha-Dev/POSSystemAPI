using POS_System_Web_API.Models.Entities;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models;
using POSSystemWebAPI.Models.DTOs;

namespace POSSystemWebAPI.Services
{

    public class UserLocationService : IUserLocationService
    {
        private readonly IUserLocationRepository _repo;
        public UserLocationService(IUserLocationRepository repo) => _repo = repo;

        public Task<List<LocationDetail>> GetAllAsync() => _repo.GetAllAsync();

        public Task SaveAsync(IEnumerable<LocationDto> dtos)
        {
            var entities = dtos.Select(d => new LocationDetail
            {
                LocationCode = d.Location_Code,
                LocationName = d.Location_Name
            });
            return _repo.UpsertRangeAsync(entities);
        }
    }
}