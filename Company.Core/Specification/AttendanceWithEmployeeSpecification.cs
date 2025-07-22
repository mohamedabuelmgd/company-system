using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class AttendanceWithEmployeeSpecification:BaseSpecification<Attendance>
    {
        public AttendanceWithEmployeeSpecification(DateTime today,int employeeId)
            : base(A => A.EmployeeId == employeeId && A.CheckIn.Date == today)
        {
            Includes.Add(A => A.Employee);
            AddOrderByDecinding(e => e.Id);
            
        }
        public AttendanceWithEmployeeSpecification(int employeeId)
            :base(A => A.EmployeeId == employeeId)
        {
            Includes.Add(A => A.Employee);
        }
    }
}
