using Company.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_1.DTOS
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Project Id")]
        public int? ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
    }
}
