using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_tut_1.Data;
using Web_API_tut_1.Models;

namespace Web_API_tut_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private ContactAPIDbContext dbContext;
        public EmployeesController(ContactAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await dbContext.Employees.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployees(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Phone = addEmployeeRequest.Phone,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,

            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Name = updateEmployeeRequest.Name;
                employee.Phone = updateEmployeeRequest.Phone;
                employee.Email = updateEmployeeRequest.Email;
                employee.Salary = updateEmployeeRequest.Salary;
                employee.Department = updateEmployeeRequest.Department;

                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }
    }
}
