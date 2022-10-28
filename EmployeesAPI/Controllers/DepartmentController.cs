using EmployeesAPI.Data;
using EmployeesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Department>>> Get()
        {
            var departments = await _context.Departments.AsNoTracking().ToListAsync();

            return Ok(departments);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if(department == null)
                return NotFound(new { message = "Department Not Found"});

            return Ok(department);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Department>> Post([FromBody]Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            
            return Ok(department);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Department>> Put(int id, [FromBody]Department department)
        {
            if (id != department.Id)
                return BadRequest(new { message = "Invalid Department" });

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Entry<Department>(department).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Department Has Already Been Updated" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Unable To Update The Department" });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Department>> Delete(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);

            if (department == null)
                return NotFound(new { message = "Department Not Found" });

            try
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return Ok(department);
            }
            catch (Exception)
            {
               return BadRequest(new { message = "Unable To Delete The Department" });
            }
        }

    }
}
