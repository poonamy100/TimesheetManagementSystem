using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimesheetManagementSystemUI.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [ForeignKey("Sector")]
        public required int SectorId { get; set; }
        public Sector sector { get; set; }
    }
}
