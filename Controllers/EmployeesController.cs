using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoEmp.data;
using DemoEmp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEmp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDb;

        public EmployeesController(EmployeeDbContext employeeDb)
        {
            _employeeDb = employeeDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           var employee = await _employeeDb.Emp.ToListAsync();
           return  Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            employee.Id= Guid.NewGuid();
            await _employeeDb.Emp.AddAsync(employee);
            await _employeeDb.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeDb.Emp.AddAsync(employee);
            await _employeeDb.SaveChangesAsync();
            return Ok(employee);
        }
    }
}