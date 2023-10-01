using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class TimeAttendance
    {
        public int Id { get; set; }
        [Required] 
        public int UserId { get; set; }
        [Required]
        public DateTime AttendaceDate { get; set; }
        [Required]
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public bool IsOnLeave { get; set; }
        public string LeaveReason { get; set; }
    }
}
