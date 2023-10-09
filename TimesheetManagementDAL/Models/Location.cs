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
        public string? Address {get;set;}

        [Required]
        [ForeignKey("Sector")]
        public required int SectorId {get;set;}
        public required Sector Sector {get;set;}
    }
}