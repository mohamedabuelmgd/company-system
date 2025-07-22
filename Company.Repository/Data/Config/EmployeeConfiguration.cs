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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Gender).IsRequired().HasMaxLength(6);
            builder.Property(P => P.Age).IsRequired();
            builder.Property(P => P.Salary).IsRequired();
            builder.HasOne(P => P.Department).WithMany(P => P.Employee)
                .HasForeignKey(P => P.DepartmentId);
            builder.HasOne(P => P.Project).WithMany(P => P.Employee)
                .HasForeignKey(P => P.ProjectId);
            builder.HasMany(S => S.Salaries).WithOne(E => E.Employee);

        }
    }
}
