using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TimesheetManagementDAL.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public required string FirstName { get;set; }
        [Required]
        public required string LastName { get;set; }
        [Required]
        [ForeignKey("Location")]
        public required int LocationId { get;set; }
    }
}