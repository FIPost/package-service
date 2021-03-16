using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Datamodels;

namespace PakketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly PackageServiceContext _context;

        public PackagesController(PackageServiceContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
            return await _context.Package.ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(Guid id)
        {
            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // GET: api/Packages/Receiver/5
        [HttpGet("Receiver/{id}")]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackagesByReceiverId(Guid id)
        {
            return await _context.Package.Where(b => b.ReceiverId == id.ToString()).ToListAsync();
        }

        // GET: api/Packages/Location/5
        [HttpGet("Location/{id}")]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackagesBylocationId(Guid id)
        {
            return await _context.Package.Where(b => b.Tickets.Last().ToDoLocationId == id.ToString()).ToListAsync();
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(Guid id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> DeletePackage(Guid id)
        {
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return package;
        }

        private bool PackageExists(Guid id)
        {
            return _context.Package.Any(e => e.Id == id);
        }
    }
}
