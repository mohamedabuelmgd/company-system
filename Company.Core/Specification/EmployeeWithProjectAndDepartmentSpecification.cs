using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class EmployeeWithProjectAndDepartmentSpecification : BaseSpecification<Employee>
    {
       //constructor to get specific employee
        public EmployeeWithProjectAndDepartmentSpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Department);
            Includes.Add(p => p.Project);
        }
        //constructor to get all products
        public EmployeeWithProjectAndDepartmentSpecification(EmployeeSpecParams employeeParams)
            :base(P =>
            string.IsNullOrEmpty(employeeParams.search)||P.Name.ToLower().Contains(employeeParams.search)&&
            (!employeeParams.ProjectId.HasValue||P.ProjectId == employeeParams.ProjectId.Value)&&
            (!employeeParams.DepartmentId.HasValue||P.DepartmentId== employeeParams.DepartmentId.Value)//chain in the constructor that have critria to make filteratiion by it 
            )
        {
            Includes.Add(p => p.Department);
            Includes.Add(p => p.Project);
            ApplyPagination(employeeParams.pageSize * (employeeParams.PageIndex - 1),employeeParams.pageSize);
            if (!string.IsNullOrEmpty(employeeParams.Sort))//show if the value is null not make sort
            {
                switch (employeeParams.Sort)//get the value of sort
                {
                    case "salaryAsc":
                        AddOrderBy(p => p.Salary);
                        break;
                    case "salaryDecs":
                        AddOrderByDecinding(p => p.Salary);
                        break;

                    default:
                        AddOrderBy(p => p.Name);//if sort with any value without salary sorted by name 
                        break;
                }
            }
        }
    }
}
