using ErrorHandling.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
       
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet(Name = "employee")]
        public async  Task<IActionResult> Get([FromHeader] int employeeId )
        {
           var result= await _employee.VerifyEmployeeExist(employeeId);
           return Ok();
        }
    }
}