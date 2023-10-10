using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using TimesheetManagementSystemUI.Models;
using TimesheetManagementDAL.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace TimesheetManagementSystemUI.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class SectorsController : Controller
    {
        private IConfiguration _configure;
        private string apiBaseUrl = "http://localhost:5283/";
        public SectorsController(IConfiguration configuration)
        {
            _configure = configuration;
        }

        // GET: Sectors
        public async Task<ActionResult> Index()
        {
            IEnumerable<Sector> sectorList = new List<Sector>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "api/Sector/Get"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    sectorList = JsonConvert.DeserializeObject<List<Sector>>(apiResponse);
                }
            }
            if (sectorList.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login");
            }
            return View(sectorList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Sector sector = new Sector();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5283/api/Sector/Details/" + id))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sector = JsonConvert.DeserializeObject<Sector>(apiResponse);

                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
            }
            return View(sector);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sector sector)
        {
            Sector insertSector = new Sector();
            using (var httpClient = new HttpClient())
            {
                // httpClient.BaseAddress = new System.Uri(apiBaseUrl);
                var postTask = httpClient.PostAsJsonAsync<Sector>("http://localhost:5283/api/Sector/Create/", sector);
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
            return View(insertSector);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5283/api/Sector/Details/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Sector = JsonConvert.DeserializeObject<Sector>(responseData);

                return View(Sector);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Sector Sec)
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("http://localhost:5283/api/Sector/Edit/" + id, Sec);
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
                HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5283/api/Sector/Details/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var Sector = JsonConvert.DeserializeObject<Sector>(responseData);

                    return View(Sector);
                }
            }
            return View("Error");
        }

        /*[HttpPost]
        public async Task<ActionResult> Delete(int id, Sector Sec)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("http://localhost:5283/api/Sectors/Delete/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }*/

    }
}

