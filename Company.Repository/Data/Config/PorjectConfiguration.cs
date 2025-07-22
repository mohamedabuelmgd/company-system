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
    public class PorjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(70);
            builder.Property(P => P.Location).IsRequired().HasMaxLength(60);
            builder.HasOne(P => P.Department).WithMany(P => P.Project)
                .HasForeignKey(P => P.DepartmentId);
            builder.HasMany(P => P.Employee).WithOne(P => P.Project)
                ;
        }
    }
}
