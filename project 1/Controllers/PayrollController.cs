using AutoMapper;
using Company.Core.Entities;
using Company.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_1.DTOS;
using project_1.Errors;
using project_1.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project_1.Controllers
{
    
    public class PayrollController : BaseApiController
    {
        private readonly IPayrollService _payrollService;
        private readonly IMapper _mapper;

        public PayrollController(IPayrollService payrollService
            ,IMapper mapper)
        {
            _payrollService = payrollService;
           _mapper = mapper;
        }


        [HttpPost("generate")]
        public async Task<ActionResult> GeneratePayroll([FromQuery] DateTime month)
        {
            await _payrollService.GeneratePayrollAsync(month);
            return Ok($"Payroll Generated for {month:MMMM yyyy}.");
        }
        [CachedAttribute(600)]
        [Authorize]
        [HttpGet("salaries")]
        public async Task<ActionResult<IReadOnlyList<Salary>>> GetSalaries([FromQuery] DateTime month)
        {
            var result=await _payrollService.GetSalariesAsync(month);
            if (result == null) return NotFound(new ApiResponse(404));

            var mappedResult =_mapper.Map<IReadOnlyList<Salary>,IReadOnlyList<SalaryDto>>(result);
            return Ok(mappedResult);
        }
    }
}
