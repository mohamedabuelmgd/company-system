using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public DateTime HireDate { get; set; } 
        public ICollection<Employee> Employee { get; set; } //navigation property Many
        public ICollection<Project> Project { get; set; }//navigation property Many

    }
}
