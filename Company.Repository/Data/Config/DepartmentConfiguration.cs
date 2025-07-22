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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.HireDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.HasMany(P => P.Employee).WithOne(P => P.Department);
            builder.HasMany(P => P.Project).WithOne(P => P.Department);
        }
    
    }
}
