using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Salary : BaseEntity
    {
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal Total => BaseSalary + Bonus - Deductions;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PayrollId { get; set; }         
        public Payroll Payroll { get; set; }
    }
}
