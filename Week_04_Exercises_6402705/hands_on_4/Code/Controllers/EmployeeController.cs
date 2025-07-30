using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIHandsOn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 10000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 101, Name = "Communication" },
                    new Skill { Id = 102, Name = "Recruitment" }
                },
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new Employee
            {
                Id = 2,
                Name = "Jane",
                Salary = 12000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "IT" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 103, Name = "C#" },
                    new Skill { Id = 104, Name = "SQL" }
                },
                DateOfBirth = new DateTime(1992, 2, 2)
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Employees;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            var emp = Employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound("Employee not found");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;
            emp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(emp);
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
