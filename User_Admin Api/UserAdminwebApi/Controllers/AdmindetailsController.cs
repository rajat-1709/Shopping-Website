using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAdminwebApi.Models;

namespace UserAdminwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmindetailsController : ControllerBase
    {
        private readonly LogincredContext _context;

        public AdmindetailsController(LogincredContext context)
        {
            _context = context;
        }

        // GET: api/Admindetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admindetail>>> GetAdmindetails()
        {
            return await _context.Admindetails.ToListAsync();
        }

        // GET: api/Admindetails/5
        [HttpGet("{uname}")]
        public async Task<ActionResult<Admindetail>> GetAdmindetail(string uname)
        {
            var admindetail = await _context.Admindetails.FindAsync(uname);

            if (admindetail == null)
            {
                return NotFound();
            }

            return admindetail;
        }

        // GET: api/Userdetails/uname/password
        [HttpGet("{uname}/{passwd}")]
        public async Task<ActionResult<Admindetail>> GetAdmindetails(string uname, string passwd)
        {
            var admindetail = _context.Admindetails.Where(e => e.Username == uname && e.Password == passwd).FirstOrDefault();

            if (admindetail == null)
            {
                return NotFound();
            }

            return admindetail ;
        }

        // PUT: api/Admindetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmindetail(string id, Admindetail admindetail)
        {
            if (id != admindetail.Username)
            {
                return BadRequest();
            }

            _context.Entry(admindetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmindetailExists(id))
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

        // POST: api/Admindetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admindetail>> PostAdmindetail(Admindetail admindetail)
        {
            _context.Admindetails.Add(admindetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdmindetailExists(admindetail.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdmindetail", new { id = admindetail.Username }, admindetail);
        }

        // DELETE: api/Admindetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmindetail(string id)
        {
            var admindetail = await _context.Admindetails.FindAsync(id);
            if (admindetail == null)
            {
                return NotFound();
            }

            _context.Admindetails.Remove(admindetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmindetailExists(string id)
        {
            return _context.Admindetails.Any(e => e.Username == id);
        }
    }
}
