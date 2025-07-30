using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Initially "api/Employee"
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new List<object>
            {
                new { Id = 1, Name = "Alice", Department = "HR" },
                new { Id = 2, Name = "Bob", Department = "IT" },
                new { Id = 3, Name = "Charlie", Department = "Finance" }
            };

            return Ok(employees);
        }
    }
}
