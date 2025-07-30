using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("standard")]
        public IActionResult GetEmployeeStandard()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 2, Name = "Recruitment" }
                    },
                    DateOfBirth = new DateTime(1990, 5, 23)
                }
            };

            return Ok(employees);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; }
        public List<Skill> Skills { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
