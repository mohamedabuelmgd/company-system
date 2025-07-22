using AutoMapper;
using Company.Core.Entities;
using Company.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_1.DTOS;
using project_1.Errors;
using project_1.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project_1.Controllers
{
  
    public class DepartmentsController : BaseApiController
    {
        
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public DepartmentsController(IUniteOfWork uniteOfWork
            ,IMapper mapper)
        {
            
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        [CachedAttribute(600)]
        [HttpGet]
        public async Task<ActionResult<DepartmentDto>> GetAllDepartments()
        {
            var departments=await _uniteOfWork.Repository<Department>().GetAllAsync();
            if (departments == null) return NotFound(new ApiResponse(404));
            var mappedDepartments =  _mapper.Map<IReadOnlyList<Department>,IReadOnlyList<DepartmentDto>>(departments);
            return Ok(mappedDepartments);
        }
        [CachedAttribute(600)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById([FromRoute] int id)
        {
            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync(id);
            if (department == null) return NotFound(new ApiResponse(404));

            var mappedDepartment = _mapper.Map<Department, DepartmentDto>(department);
            return Ok(mappedDepartment);
        }
        [Authorize]
        [HttpPost]
        public  async Task<ActionResult<Department>> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            var mappedDepartment=_mapper.Map<DepartmentDto,Department>(departmentDto);
            await _uniteOfWork.Repository<Department>().CreateAsync(mappedDepartment);
            return Ok(departmentDto);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Department>> UpdateDepartment([FromQuery] int id, [FromBody] DepartmentDto departmentDto)
        {
            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync(id);
            var mappedDepartment = _mapper.Map(departmentDto,department);
            _uniteOfWork.Repository<Department>().Update(mappedDepartment);
            return Ok(departmentDto);
        }
    }
}
