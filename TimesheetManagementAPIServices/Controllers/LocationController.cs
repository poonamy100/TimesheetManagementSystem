using Microsoft.AspNetCore.Mvc;
using TimesheetManagementDAL.Models;
using TimesheetManagementAPIServices.Repositorys;

namespace TimesheetManagementAPIServices.Controllers
{
    [ApiController]
   //[Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository _locationRepository)
        {
            this._locationRepository = _locationRepository;
        }

        [HttpGet]
        [Route("api/Location/Get")]
        public async Task<IEnumerable<Location>> Get()
        {
            return await _locationRepository.GetAllLocations();
        }

        [HttpGet]
        [Route("api/Location/Details/{id}")]
        public async Task<Location> Details(int? id)
        {
            var result = await _locationRepository.GetLocationById(id);
            return result;
        }
        [HttpPost]
        [Route("api/Location/Create")]
        public async Task CreateAsync([FromBody] Location location)
        {
            //if (ModelState.IsValid)
            //{
                await _locationRepository.Add(location);
            //}
        }


        [HttpPut]
        [Route("api/Location/Edit/{id}")]
        public async Task EditAsync(int id, Location location)
        {
            if (ModelState.IsValid)
            {
                await _locationRepository.Update(id, location);

            }
        }
        [HttpDelete]
        [Route("api/Location/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _locationRepository.Delete(id);
        }
    }
}
