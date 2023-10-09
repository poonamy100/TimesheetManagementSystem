using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetManagementDAL.Models
{
    public class TimeSlot
    {
        public int Id {get;set;}
        [Required]
        [ForeignKey("AppUser")]
        public required string AppUserId {get;set;}
        public required AppUser AppUser {get;set;}
        public DateTime Start {get;set;}
        public DateTime End {get;set;}
    }
}

/*
https://stackoverflow.com/questions/12986114/get-the-system-date-and-split-day-month-and-year
*/