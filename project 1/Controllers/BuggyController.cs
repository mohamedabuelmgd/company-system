using Company.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_1.Errors;

namespace project_1.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var employee = _context.Employees.Find(200);
            if (employee == null) return NotFound(new ApiResponse(404));
            return Ok(employee);
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var employee = _context.Employees.Find(200);
            var employeetoreturn = employee.ToString();
            return Ok(employeetoreturn);
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }

}
