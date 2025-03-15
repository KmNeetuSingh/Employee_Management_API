using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(int id, Employee employee); // Update Employee
        Task<bool> DeleteEmployee(int id); //  Delete Employee
    }
}

// using here solid principles o stands for open closed principle.
// open for extension and closed for modification.
// we can add new features without changing the existing code.
