using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using TimesheetManagementSystemUI.Models;
using TimesheetManagementDAL.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TimesheetManagementSystemUI.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class LocationsController : Controller
    {
        private IConfiguration _configure;
        private string apiBaseUrl = "http://localhost:5283/";
        public LocationsController(IConfiguration configuration)
        {
            _configure = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Location> locationList = new List<Location>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "api/Location/Get"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    locationList = JsonConvert.DeserializeObject<List<Location>>(apiResponse);
                }
            }
            return View(locationList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Location location = new Location();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5283/api/Location/Details/" + id))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        location = JsonConvert.DeserializeObject<Location>(apiResponse);

                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
            }
            return View(location);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            Location insertLocation = new Location();
            using (var httpClient = new HttpClient())
            {
                // httpClient.BaseAddress = new System.Uri(apiBaseUrl);
                var postTask = httpClient.PostAsJsonAsync<Location>("http://localhost:5283/api/Location/Create/", location);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result;
                    ModelState.AddModelError(string.Empty, "Server Error...Please Contact Administrator");

                }
            }
            return View(insertLocation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5283/api/Location/Details/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var location = JsonConvert.DeserializeObject<Location>(responseData);

                return View(location);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Location loc)
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("http://localhost:5283/api/Location/Edit/" + id, loc);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5283/api/Location/Details/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var Location = JsonConvert.DeserializeObject<Location>(responseData);

                    return View(Location);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, Location Loc)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("http://localhost:5283/api/Location/Delete/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }

    }
}