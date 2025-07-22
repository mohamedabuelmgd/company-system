using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Payroll : BaseEntity
    {
        public DateTime Month { get; set; }
        public bool IsGenerated { get; set; }

        public ICollection<Salary> Salaries { get; set; }

    }
}
