using TimesheetManagementDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetManagementAPIServices.Repositorys
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> GetAllSectors();
        Task<Sector> GetSectorById(int? id);
        Task Add(Sector sector);
        Task Update(int id, Sector sector);
        Task Delete(int id);
    }
}
