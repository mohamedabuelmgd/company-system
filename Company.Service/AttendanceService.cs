using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service
{
    public class AttendanceService : IAttendanceService
    {
       
        private readonly IUniteOfWork _uniteOfWork;

        public AttendanceService(IUniteOfWork uniteOfWork)
        {
           
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IReadOnlyList<Attendance>> GetAttendanceAsync(int employeeId)
        {
            var spec = new AttendanceWithEmployeeSpecification(employeeId);
            var result = await _uniteOfWork.Repository<Attendance>().GetAllattendanceByIdWithSpecAsync(spec);
            return result;

        }

        public async Task<string> RecordeCheckInAsync(int employeeId)
        {
            var employee = await _uniteOfWork.Repository<Employee>().GetByIdAsync(employeeId);
            var employeeName = employee.Name;
            var spec = new AttendanceWithEmployeeSpecification(employeeId);
            var record = await _uniteOfWork.Repository<Attendance>().GetByIdWithSpecAsync(spec);
            if ((record==null) ||(record.CheckIn != DateTime.UtcNow.Date) )
            {
                var attendance = new Attendance
                {
                    EmployeeId = employeeId,
                    CheckIn = DateTime.UtcNow
                };
                await _uniteOfWork.Repository<Attendance>().CreateAsync(attendance);
                return $"Hi {employeeName} Check In Is Completed.";
            }
            else
                return $"{employeeName} you are Check In Before..!!";

        }

        public async Task<string> RecordeCheckOutAsync(int employeeId)
        {
            var employee = await _uniteOfWork.Repository<Employee>().GetByIdAsync(employeeId);
            var employeeName = employee.Name;
            var toDay = DateTime.UtcNow.Date;
            var spec = new AttendanceWithEmployeeSpecification(toDay, employeeId);
            var record = await _uniteOfWork.Repository<Attendance>().GetByIdWithSpecAsync(spec);
            if (record != null && !record.CheckOut.HasValue)
            {
                record.CheckOut = DateTime.UtcNow;
                _uniteOfWork.Repository<Attendance>().Update(record);
                return $"Bye {employeeName} Check Out Is Completed.";
            }
            else
                return $"{employeeName} You Are Check Out Before..!!";
        }
    }
}
