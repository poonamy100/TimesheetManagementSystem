using Microsoft.AspNetCore.Mvc;
using TimesheetManagementDAL.Models;
using TimesheetManagementAPIServices.Repositorys;

namespace TimesheetManagementAPIServices.Controllers
{
    [ApiController]
   // [Route("[controller]")]
    public class SectorController : Controller
    {
        private readonly ISectorRepository _sectorRepository;
        public SectorController(ISectorRepository _sectorRepository)
        {
            this._sectorRepository = _sectorRepository;
        }

        [HttpGet]
        [Route("api/Sectors/Get")]
        public async Task<IEnumerable<Sector>> Get()
        {
            return await _sectorRepository.GetAllSectors();
        }

        [HttpGet]
        [Route("api/Sectors/Details/{id}")]
        public async Task<Sector> Details(int? id)
        {
            var result = await _sectorRepository.GetSectorById(id);
            return result;
        }
        [HttpPost]
        [Route("api/Sectors/Create")]
        public async Task CreateAsync([FromBody] Sector sector)
        {
            if (ModelState.IsValid)
            {
                await _sectorRepository.Add(sector);
            }
        }


        [HttpPut]
        [Route("api/Sectors/Edit/{id}")]
        public async Task EditeAsync(int id, Sector sector)
        {
            if (ModelState.IsValid)
            {
                await _sectorRepository.Update(id, sector);

            }
        }
        [HttpDelete]
        [Route("api/Sectors/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _sectorRepository.Delete(id);
        }
    }
}
