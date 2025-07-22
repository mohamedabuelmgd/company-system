using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service
{
    public interface IAttendanceService
    {
        Task<string> RecordeCheckInAsync(int employeeId);
        Task<string> RecordeCheckOutAsync(int employeeId);
        Task<IReadOnlyList<Attendance>> GetAttendanceAsync(int employeeId);
    }
}
