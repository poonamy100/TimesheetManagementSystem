using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementDAL.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {       
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Location> Locations {get;set;}
        public DbSet<Sector> Sectors {get;set;}
        public DbSet<TimeSlot> TimeSlots {get;set;}

       
     
    }
}