using Microsoft.EntityFrameworkCore;
using TimesheetManagementDAL.Data;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementAPIServices.Repositorys
{

    public class LocationRepository : ILocationRepository
    {

        private readonly AppDbContext _appDbContext;
        public LocationRepository(AppDbContext dbContext)
        {
            this._appDbContext = dbContext;
        }


        public async Task Add(Location location)
        {
            _appDbContext.Locations.Add(location);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                Location location = await _appDbContext.Locations.FindAsync(id);
                _appDbContext.Locations.Remove(location);
                _appDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            try
            {
                var location = await _appDbContext.Locations.ToListAsync();
                return location;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Location> GetLocationById(int? id)
        {
            try
            {
                Location location = await _appDbContext.Locations.FindAsync(id);
                if (location == null)
                {
                    return null;
                }
                return location;
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, Location location)
        {
            {
                try
                {
                    var loc = _appDbContext.Locations.Find(id);
                    if (loc != null)
                    {
                        loc.SectorId = location.SectorId;
                        loc.Address = location.Address;                        
                        _appDbContext.SaveChanges();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
