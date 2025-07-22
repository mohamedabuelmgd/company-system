using AutoMapper;
using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Core.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_1.DTOS;
using project_1.Errors;
using project_1.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_1.Controllers
{

    public class EmployeesController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IUniteOfWork _uniteOfWork;
        

        public EmployeesController( IMapper mapper
            ,IUniteOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
           
        }
        [CachedAttribute(600)]
        [HttpGet] //api/Employees
        public async Task<ActionResult<EmployeeDto>> GetEmployees([FromQuery] EmployeeSpecParams employeeParams)
        {
            var spec = new EmployeeWithProjectAndDepartmentSpecification(employeeParams);
            //to get the all employee from the data base by the geniric repo
            var employees = await _uniteOfWork.Repository<Employee>().GetAllWithSpecAsync(spec);
            if (employees == null) return NotFound(new ApiResponse(404));

            var Data = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeDto>>(employees);
            var CountSpec = new EmployeeWithFiltersCountSpec(employeeParams);
            var Count = await _uniteOfWork.Repository<Employee>().GetCountAsync(CountSpec);//to get the count of all employee 
            return Ok(new Pagination<EmployeeDto>(employeeParams.PageIndex, employeeParams.pageSize, Count, Data));//make the data that the user show is from dto not the employee class
        }
        [CachedAttribute(600)]
        [HttpGet("{id}")] //api/Employees/Id
        //to get the employee with the id 
        public async Task<ActionResult<EmployeeDto>> GetEmployeesById(int id)
        {
            var spec = new EmployeeWithProjectAndDepartmentSpecification(id);
            //to get the all employee from the data base by the geniric repo

            var employee = await _uniteOfWork.Repository<Employee>().GetByIdWithSpecAsync(spec);
            if (employee == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Employee, EmployeeDto>(employee));//make the data that the user show is from dto not the employee class
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {

            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync((int)employeeDto.DepartmentId);
            var project = await _uniteOfWork.Repository<Project>().GetByIdAsync((int)employeeDto.ProjectId);
            var mappedEmployee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            mappedEmployee.Department = department;
            mappedEmployee.Project = project;
            await _uniteOfWork.Repository<Employee>().CreateAsync(mappedEmployee);
            return Ok(employeeDto);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee([FromQuery] int id, [FromBody] EmployeeDto employeeDto)
        {
            var employee = await _uniteOfWork.Repository<Employee>().GetByIdAsync(id);
            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync((int)employeeDto.DepartmentId);
            var project = await _uniteOfWork.Repository<Project>().GetByIdAsync((int)employeeDto.ProjectId);
            var mappedEmployee = _mapper.Map(employeeDto,employee);
            mappedEmployee.Department = department;
            mappedEmployee.Project = project;


            _uniteOfWork.Repository<Employee>().Update(mappedEmployee);



            return Ok(employeeDto);


        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteEmployee([FromRoute] int id)
        {
            var employee = await _uniteOfWork.Repository<Employee>().GetByIdAsync(id);
         
            await _uniteOfWork.Repository<Employee>().Delete(employee);
            

        }


    }
}
