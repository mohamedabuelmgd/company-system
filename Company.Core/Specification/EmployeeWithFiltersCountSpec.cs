using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class EmployeeWithFiltersCountSpec:BaseSpecification<Employee>
    {
        public EmployeeWithFiltersCountSpec(EmployeeSpecParams employeeParams)
           : base(P =>
           string.IsNullOrEmpty(employeeParams.search) || P.Name.ToLower().Contains(employeeParams.search) &&
           (!employeeParams.ProjectId.HasValue || P.ProjectId == employeeParams.ProjectId.Value) &&
           (!employeeParams.DepartmentId.HasValue || P.DepartmentId == employeeParams.DepartmentId.Value)//chain in the constructor that have critria to make filteratiion by it 
           )
        {

        }
    }
}
