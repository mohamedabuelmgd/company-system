using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class SalaryWithEmployeeAndPayrollSpecification :BaseSpecification<Salary>
    {
        public SalaryWithEmployeeAndPayrollSpecification()
            : base (S=>S.Employee!=null&&S.Employee.Id>0)
        {
            Includes.Add(E => E.Employee);
            Includes.Add(P => P.Payroll);
            
        }
    }
}
