using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface IPayrollService
    {
        Task GeneratePayrollAsync(DateTime month);
        Task<IReadOnlyList<Salary>> GetSalariesAsync(DateTime month);
    }
}
