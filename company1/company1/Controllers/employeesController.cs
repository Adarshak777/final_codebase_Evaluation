using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using company1.Data;
using company1.Models;

namespace company1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : ControllerBase
    {
        private readonly company1Context _context;

        public employeesController(company1Context context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<employee>>> Getemployee()
        {
          if (_context.employee == null)
          {
              return NotFound();
          }
            return await _context.employee.ToListAsync();
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<employee>> Getemployee(int id)
        {
          if (_context.employee == null)
          {
              return NotFound();
          }
            var employee = await _context.employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemployee(int id, employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<employee>> Postemployee(employee employee)
        {
          if (_context.employee == null)
          {
              return Problem("Entity set 'company1Context.employee'  is null.");
          }
            _context.employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {
            if (_context.employee == null)
            {
                return NotFound();
            }
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool employeeExists(int id)
        {
            return (_context.employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
