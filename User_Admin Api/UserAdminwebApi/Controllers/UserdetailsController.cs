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
    public class UserdetailsController : ControllerBase
    {
        private readonly LogincredContext _context;

        public UserdetailsController(LogincredContext context)
        {
            _context = context;
        }

        // GET: api/Userdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userdetail>>> GetUserdetails()
        {
            return await _context.Userdetails.ToListAsync();
        }

        // GET: api/Userdetails/uname/password
        [HttpGet("{uname}/{passwd}")]
        public async Task<ActionResult<Userdetail>> GetUserdetail(string uname , string passwd)
        {
            var userdetail = _context.Userdetails.Where(e=>e.Uname==uname && e.Passwd==passwd).FirstOrDefault();

            if (userdetail == null)
            {
                return NotFound();
            }

            return userdetail;
        }
        // GET: api/Userdetails/uname/password
        [HttpGet("{uname}")]
        public async Task<ActionResult<Userdetail>> GetUserAccountdetail(string uname)
        {
            var userdetail = _context.Userdetails.Where(e => e.Uname == uname).FirstOrDefault();

            if (userdetail == null)
            {
                return NotFound();
            }

            return userdetail;
        }

        // PUT: api/Userdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserdetail(string id, Userdetail userdetail)
        {
            if (id != userdetail.Uname)
            {
                return BadRequest();
            }

            _context.Entry(userdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserdetailExists(id))
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

        // POST: api/Userdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userdetail>> PostUserdetail(Userdetail userdetail)
        {
            _context.Userdetails.Add(userdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserdetailExists(userdetail.Uname))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserdetail", new { id = userdetail.Uname }, userdetail);
        }

        // DELETE: api/Userdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserdetail(string id)
        {
            var userdetail = await _context.Userdetails.FindAsync(id);
            if (userdetail == null)
            {
                return NotFound();
            }

            _context.Userdetails.Remove(userdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserdetailExists(string id)
        {
            return _context.Userdetails.Any(e => e.Uname == id);
        }
    }
}
