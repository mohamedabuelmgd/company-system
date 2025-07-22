using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; } // navigation one 
        public int? ProjectId { get; set; }
        public Project Project { get; set; }//navigation prop of one

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<Salary> Salaries { get; set; }

    }
}
