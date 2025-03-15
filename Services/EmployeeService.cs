using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            var existingEmployee = await _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null) return null;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return await _employeeRepository.UpdateEmployee(existingEmployee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null) return false;

            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
