using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimesheetManagementDAL.Data;

namespace TimesheetManagementSystemUI.Controllers
{
    //[Route("[controller]")]
    public class ManageData : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ManageData> _logger;

        public ManageData(ILogger<ManageData> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Users/ViewUsers
        public async Task<IActionResult> ViewUsers()
        {
            return (_context.Users != null) ? View(await _context.Users.ToListAsync()) : Problem("Entity Set Users Empty");
        }
        // POST: Users/ViewUsers/
        [HttpPost]
        public IActionResult ViewUsers(int? Id)
        {
            return View();
        }

        // GET: ManageData/ViewLocations
        public IActionResult ViewLocations()
        {
            return View();
        }
        // POST: ManageData/ViewLocations/
        [HttpPost]
        public IActionResult ViewLocations(int? Id)
        {
            return View();
        }

        // GET: ManageData/ViewSectors
        public IActionResult ViewSectors()
        {
            return View();
        }
        // POST: ManageData/ViewSectors/
        [HttpPost]
        public IActionResult ViewSectors(int? Id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}