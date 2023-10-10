using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimesheetManagementDAL.Data;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementSystemUI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> ViewTimeSlots()
        {
            return (_context.Users != null) ? View(await _context.TimeSlots.ToListAsync()) : Problem("Entity Set Users Empty");
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeSlots(DateTime Date, DateTime Start, DateTime End)
        {
            AppUser CurrentUser = await _context.Users.FirstOrDefaultAsync(k => k.UserName == User.Identity.Name);
            TimeSlot newTimeSlot = new TimeSlot()
            {
                AppUserId = CurrentUser.Id,
                AppUser = CurrentUser,
                Date = Date,
                Start = Start,
                End = End
            };
            
             _context.TimeSlots.Add(newTimeSlot);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ViewTimeSlots));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTimeSlots(int SlotId)
        {
            TimeSlot timeSlot = await _context.TimeSlots.FindAsync(SlotId);
            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewTimeSlots));
        }

        // GET : /Users/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}