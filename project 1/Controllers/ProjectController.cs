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
using System.Threading.Tasks;

namespace project_1.Controllers
{
  
    public class ProjectController : BaseApiController
    {
        
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ProjectController(IUniteOfWork uniteOfWork
            ,IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        [CachedAttribute(600)]
        [HttpGet]
        public async Task<ActionResult<ProjectDto>> GetAllProjects()
        {
            var spec = new ProjectWithDepartmentSpecification();
            var projects = await _uniteOfWork.Repository<Project>().GetAllWithSpecAsync(spec);
            if (projects == null) return NotFound(new ApiResponse(404));

            var mappedProjects = _mapper.Map<IReadOnlyList <Project>,IReadOnlyList<ProjectDto>>(projects);
            
            return Ok(mappedProjects);
        }
        [CachedAttribute(600)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var spec = new ProjectWithDepartmentSpecification(id);
            var project = await _uniteOfWork.Repository<Project>().GetByIdWithSpecAsync(spec);
            if (project == null) return NotFound(new ApiResponse(404));

            var mappedProject = _mapper.Map<Project, ProjectDto>(project);
            return Ok(mappedProject);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody]ProjectDto projectDto)
        {
            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync((int)projectDto.DepartmentId);
            var mappedProject=_mapper.Map<ProjectDto,Project>(projectDto);
            mappedProject.Department = department;
            await _uniteOfWork.Repository<Project>().CreateAsync(mappedProject);
            return Ok(projectDto);
            

        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProjectDto>> UpdateProject([FromQuery] int id,[FromBody] ProjectDto projectDto)
        {
            var spec = new ProjectWithDepartmentSpecification(id);
            var project = await _uniteOfWork.Repository<Project>().GetByIdWithSpecAsync(spec);
            var department = await _uniteOfWork.Repository<Department>().GetByIdAsync((int)projectDto.DepartmentId);
            var mappedProject = _mapper.Map(projectDto,project);
            mappedProject.Department = department;
            _uniteOfWork.Repository<Project>().Update(mappedProject);
            return Ok(projectDto);

        }

    }
}
