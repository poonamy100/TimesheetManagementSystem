using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetManagementDAL.Models
{
    public class Sector
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public required string Name {get;set;}
    }
}