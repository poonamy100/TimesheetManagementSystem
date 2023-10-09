using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagementDAL.Data;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementAPIServices.Repositorys
{

    public class SectorRepository : ISectorRepository
    {

        private readonly AppDbContext _appDbContext;


        public SectorRepository(AppDbContext dbContext)
        {
            this._appDbContext = dbContext;
        }

        public async Task Add(Sector sector)
        {
            _appDbContext.Sectors.Add(sector);
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
                Sector sector = await _appDbContext.Sectors.FindAsync(id);
                _appDbContext.Sectors.Remove(sector);
                _appDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Sector>> GetAllSectors()
        {
            try
            {
                var sector = await _appDbContext.Sectors.ToListAsync();
                return sector;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Sector> GetSectorById(int? id)
        {
            try
            {
                Sector sector = await _appDbContext.Sectors.FindAsync(id);
                if (sector == null)
                {
                    return null;
                }
                return sector;
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, Sector sector)
        {
            {
                try
                {
                    var sec = _appDbContext.Sectors.Find(id);
                    if (sec != null)
                    {
                        sec.Name = sector.Name;                        
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
