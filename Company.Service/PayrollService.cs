using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Core.Services;
using Company.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service
{
    public class PayrollService : IPayrollService
    {

        private readonly IUniteOfWork _uniteOfWork;

        public PayrollService(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task GeneratePayrollAsync(DateTime month)
        {

            var payroll = new Payroll
            {
                Month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                IsGenerated = true
            };
            await _uniteOfWork.Repository<Payroll>().CreateAsync(payroll);
            var employees = await _uniteOfWork.Repository<Employee>().GetAllAsync();
            foreach (var Emp in employees)
            {
                var spec = new AttendanceWithEmployeeSpecification(Emp.Id);
                var empAttendance = await _uniteOfWork.Repository<Attendance>().GetAllattendanceByIdWithSpecAsync(spec);
                int workingDays = empAttendance.Count;
                int totalWorkingDays = 26;
                decimal perDaySalary = Emp.Salary / totalWorkingDays;
                int absentDays = totalWorkingDays - workingDays;
                decimal deduction = absentDays * perDaySalary;
                var salary = new Salary
                {
                    EmployeeId = Emp.Id,
                    PayrollId = payroll.Id,
                    BaseSalary = Emp.Salary,
                    Bonus = 0,
                    Deductions = deduction
                };
                await _uniteOfWork.Repository<Salary>().CreateAsync(salary);
            }
        }

        public async Task<IReadOnlyList<Salary>> GetSalariesAsync(DateTime month)
        {
            var spec = new SalaryWithEmployeeAndPayrollSpecification();

            return await _uniteOfWork.Repository<Salary>().GetAllWithSpecAsync(spec);
        }
    }
}
