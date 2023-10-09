using System.ComponentModel.DataAnnotations;

namespace TimesheetManagementSystemUI.Models
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
