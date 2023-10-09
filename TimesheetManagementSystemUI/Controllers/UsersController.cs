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
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Users/Dashboard
        public async Task<IActionResult>  Dashboard()
        {
            return (_context.Users != null) ? View(await _context.Users.ToListAsync()) : Problem("Entity Set Users Empty");
        }

        // POST: Users/Dashboard
        [HttpPost]
        public IActionResult Dashboard(int? Id)
        {
            return View();
        }

        // GET: Users/ViewTimeSlots
        public IActionResult ViewTimeSlots()
        {
            return View();
        }
        // POST: Users/ViewTimeSlots/
        [HttpPost]
        public IActionResult ViewTimeSlots(int? Id)
        {
            return View();
        }

        // GET : /Users/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}