using Company.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Data.Config
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasOne(E => E.Employee).WithMany(S => S.Salaries)
                 .HasForeignKey(S => S.EmployeeId);
            builder.HasOne(P => P.Payroll).WithMany(S => S.Salaries)
                .HasForeignKey(S => S.PayrollId);
        }
    }
}
