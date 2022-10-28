using EmployeesAPI.Data;
using EmployeesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var employees = await _context.Employees.AsNoTracking().ToListAsync();

            return Ok(employees);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null) 
                return NotFound(new { message = "Employee Not Found!" });

            return Ok(employee);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Employee>> Post(
            [FromBody]Employee employee,
            [FromServices]DataContext _context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid Employee" });

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> Put(
            int id,
            [FromBody]Employee employee,
            [FromServices]DataContext _context)
        {
            if (id != employee.Id)
                return BadRequest(new { message = "Invalid Employee" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Entry<Employee>(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Employee Has Already Been Updated" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Unable To Update the Employee" });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null) 
                return NotFound(new { message = "Employee Not Found" });

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Unable To Remove The Employee" });
            }
        }
    }
}
