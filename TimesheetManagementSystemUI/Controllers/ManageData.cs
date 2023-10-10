using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimesheetManagementDAL.Data;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementSystemUI.Controllers
{
    //[Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class ManageData : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ManageData> _logger;

        public ManageData(ILogger<ManageData> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        //MANAGE USERS ------------------------------------------------------------------------------//
        // GET: ManageData
        public async Task<IActionResult> ViewUsers()
        {
            List<AppUser> Users = (
                from U in _context.Users
                join l in _context.Locations on U.LocationId equals l.Id into Group1
                from dd1 in Group1.DefaultIfEmpty()
                select new AppUser
                {
                    Id = U.Id,
                    FirstName = U.FirstName,
                    LastName = U.LastName,
                    Description = U.Description,
                    LocationId = U.LocationId,
                    Location = U.Location
                }
                ).ToList();
                
            return View(Users);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(AppUser user)
        {
            AppUser UpdatedAppUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            UpdatedAppUser.FirstName = user.FirstName;
            UpdatedAppUser.LastName = user.LastName;
            UpdatedAppUser.LocationId = user.LocationId;
            await _context.SaveChangesAsync();
 
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string Id)
        {
            AppUser AppUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            _context.Users.Remove(AppUser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ViewUsers));
        }
        //-------------------------------------------------------------------------------------------//

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