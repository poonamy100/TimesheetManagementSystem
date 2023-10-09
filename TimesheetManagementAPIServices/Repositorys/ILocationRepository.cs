using TimesheetManagementDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetManagementAPIServices.Repositorys
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetLocationById(int? id);
        Task Add(Location location);
        Task Update(int id, Location location);
        Task Delete(int id);
    }
}
