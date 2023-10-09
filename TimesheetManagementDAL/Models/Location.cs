using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimesheetManagementDAL.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [ForeignKey("Sector")]
        public int SectorId { get; set; }

        public string SectorName { get; set; }
        public Sector sector { get; set; }

    }
}