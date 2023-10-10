using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetManagementDAL.Data
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlServer("Server=DESKTOP-JITURAO;Database=TMSDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TimeSheetDB;User ID=sa;Password=MyDatabase40;Encrypt=False");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
