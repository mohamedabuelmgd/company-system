using AutoMapper;
using Company.Core.Entities;
using project_1.DTOS;

namespace project_1.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(E => E.DepartmentName, o => o.MapFrom(D => D.Department.Name))
                .ForMember(E => E.ProjectName, o => o.MapFrom(P => P.Project.Name))
                .ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Project, ProjectDto>()
                .ForMember(P => P.DepartmentId, o => o.MapFrom(D => D.Department.Id)).ReverseMap();
            CreateMap<Attendance, AttendanceEmployeeDto>()
                .ForMember(A=>A.EmployeeId,o=>o.MapFrom(E=>E.Employee.Id))
                .ForMember(A => A.TotalHours, o => o.MapFrom(E => E.TotalHours.HasValue?E.TotalHours.Value.TotalHours:(double?)null))
                .ReverseMap();
            CreateMap<Salary, SalaryDto>()
                .ForMember(S => S.EmployeeId, o => o.MapFrom(E => E.Employee.Id))
                .ForMember(S => S.PayrollId, o => o.MapFrom(S => S.Payroll.Id))
                .ReverseMap();

        }

    }
}
