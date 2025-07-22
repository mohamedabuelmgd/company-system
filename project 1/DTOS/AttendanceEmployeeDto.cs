using System;

namespace project_1.DTOS
{
    public class AttendanceEmployeeDto
    {
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
       
        public double? TotalHours { get; set; } 
    }
}
