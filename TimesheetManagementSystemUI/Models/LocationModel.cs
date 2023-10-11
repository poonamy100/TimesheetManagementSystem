using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimesheetManagementSystemUI.Models
{
    public class LocationModel
    {
        public int Id { get; set; }   
        public string? Address { get; set; }
        public int SectorId { get; set; }
        
        public static List<SelectListItem> ListofSectors { get; set; }

    }
}
