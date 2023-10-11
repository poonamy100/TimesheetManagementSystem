using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        
        public Sector Sector { get; set; }

    }
}