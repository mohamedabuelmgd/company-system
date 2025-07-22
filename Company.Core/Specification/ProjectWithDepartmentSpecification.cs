using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Specification
{
    public class ProjectWithDepartmentSpecification:BaseSpecification<Project>
    {
        public ProjectWithDepartmentSpecification()
        {
            Includes.Add(P => P.Department);
        }
        public ProjectWithDepartmentSpecification(int id) :base(P=>P.Id==id)
        {
            Includes.Add(P => P.Department);
        }

    }
}
