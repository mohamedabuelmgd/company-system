using AutoMapper;
using Company.Core.Entities;
using Company.Core.Repositories;
using Company.Service;
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

    public class AttendanceController : BaseApiController
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;
        

        public AttendanceController(IAttendanceService attendanceService
            ,IMapper mapper
            )
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
            
        }
        
        [HttpPost("checkin/{employeeId}")]
        public async Task<ActionResult> CheckIn(int employeeId)
        {
            var value= await _attendanceService.RecordeCheckInAsync(employeeId);
            if (value == null) return NotFound(new ApiResponse(404));
            return Ok(value);
        }
        
        [HttpPost("checkout/{employeeId}")]
        public async Task<ActionResult> CheckOut(int employeeId)
        {
            var value =await _attendanceService.RecordeCheckOutAsync(employeeId);
            if (value == null) return NotFound(new ApiResponse(404));

            return Ok(value);
        }
        [CachedAttribute(600)]
        [Authorize]
        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IReadOnlyList<Attendance>>> GetEmployeeAttendance(int employeeId)
        {
            var result = await _attendanceService.GetAttendanceAsync(employeeId);
            if (result == null) return NotFound(new ApiResponse(404));
            var mapped = _mapper.Map<IEnumerable<AttendanceEmployeeDto>>(result);
            return Ok(mapped);
        }
    }
}
