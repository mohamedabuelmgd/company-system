using Company.Core.Entities;

namespace project_1.DTOS
{
    public class SalaryDto
    {
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public int EmployeeId { get; set; }
        public int PayrollId { get; set; }
    }
}
