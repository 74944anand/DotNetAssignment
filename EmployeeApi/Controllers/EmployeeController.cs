using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Cors;

namespace EmployeeApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpDataContext _context;

        public EmployeeController(EmpDataContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        [EnableCors]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors]
        public async Task<IActionResult> PutTable(int id, Table table)
        {
            if (id != table.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
          if (_context.Tables == null)
          {
              return Problem("Entity set 'EmpDataContext.Tables'  is null.");
          }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { id = table.EmployeeId }, table);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        [EnableCors]
        public async Task<IActionResult> DeleteTable(int id)
        {
            if (_context.Tables == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(int id)
        {
            return (_context.Tables?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
