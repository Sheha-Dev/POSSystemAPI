using Microsoft.EntityFrameworkCore;
using POS_System_Web_API.Models.Entities;
using POSSystemWebAPI.Interfaces;
using POSSystemWebAPI.Models;

namespace POSSystemWebAPI.Repositories
{

    public class UserLocationRepository : IUserLocationRepository
    {
        private readonly POSDbContext _db;
        public UserLocationRepository(POSDbContext db) => _db = db;

        public async Task<List<LocationDetail>> GetAllAsync() =>
            await _db.Locations.AsNoTracking()
                .OrderBy(x => x.LocationName)
                .ToListAsync();

        // EF equivalent of MERGE: match on Location_Code, update or insert
        public async Task UpsertRangeAsync(IEnumerable<LocationDetail> incoming)
        {
            var list = incoming.ToList();
            var codes = list.Select(x => x.LocationCode).ToList();

            var existing = await _db.Locations
                .Where(l => codes.Contains(l.LocationCode))
                .ToDictionaryAsync(l => l.LocationCode);

            foreach (var loc in list)
            {
                if (existing.TryGetValue(loc.LocationCode, out var found))
                    found.LocationName = loc.LocationName;          // update
                else
                    _db.Locations.Add(new LocationDetail            // insert
                    {
                        LocationCode = loc.LocationCode,
                        LocationName = loc.LocationName
                    });
            }

            // one implicit transaction — all rows commit together or none do
            await _db.SaveChangesAsync();
        }
    }
}