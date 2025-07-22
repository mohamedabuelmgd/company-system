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
    public class AttendanceConfiguration:IEntityTypeConfiguration<Attendance>
    {
        

        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasOne(A => A.Employee).WithMany(A => A.Attendances).HasForeignKey(A => A.EmployeeId);
        }
    }
}
