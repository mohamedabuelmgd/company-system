using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Project : BaseEntity
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }//navigation property one 

        public ICollection<Employee> Employee { get; set; }//navigation property many
    }
}
