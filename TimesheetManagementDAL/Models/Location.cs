using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetManagementDAL.Models
{
    public class Location
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public string? Address;
        [Required]
        [ForeignKey("Sector")]
        public required int SectorId;
    }
}