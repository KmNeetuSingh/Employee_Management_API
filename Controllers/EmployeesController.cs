using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required.");

            var newEmployee = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required.");

            var updatedEmployee = await _employeeService.UpdateEmployee(id, employee);
            if (updatedEmployee == null)
                return NotFound("Employee not found.");
            
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await _employeeService.DeleteEmployee(id);
            if (!isDeleted)
                return NotFound("Employee not found.");

            return NoContent();
        }
    }
}
