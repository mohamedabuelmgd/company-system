using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Attendance : BaseEntity
    {
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public TimeSpan? TotalHours => CheckOut.HasValue ? CheckOut.Value - CheckIn : null;
        public int  EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
