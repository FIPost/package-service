using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;

namespace PakketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly PackageServiceContext _context;
        private readonly IDtoConverter<Package, PackageRequest, PackageResponse> _converter;

        public PackagesController(PackageServiceContext context, IDtoConverter<Package, PackageRequest, PackageResponse> converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageResponse>>> GetPackage()
        {
            List<Package> packages = await _context.Package.ToListAsync();

            return _converter.ModelToDto(packages);
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponse>> GetPackage(Guid id)
        {
            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return _converter.ModelToDto(package);
        }

        // GET: api/Packages/Receiver/5
        [HttpGet("Receiver/{id}")]
        public async Task<ActionResult<IEnumerable<PackageResponse>>> GetPackagesByReceiverId(Guid id)
        {
            List<Package> packages = await _context.Package.Where(b => b.ReceiverId == id.ToString()).ToListAsync();

            return _converter.ModelToDto(packages);
        }

        // GET: api/Packages/Location/5
        [HttpGet("Location/{id}")]
        public async Task<ActionResult<IEnumerable<PackageResponse>>> GetPackagesBylocationId(Guid id)
        {
            List<Package> packages = await _context.Package.Where(b => b.Tickets.Last().ToDoLocationId == id.ToString()).ToListAsync();

            return _converter.ModelToDto(packages);
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
        public async Task<ActionResult<PackageResponse>> PostPackage(PackageRequest dto)
        {
            Package package = _converter.DtoToModel(dto);
            package.TrackAndTraceId = package.Id.ToString();
            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, _converter.ModelToDto(package));
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackageResponse>> DeletePackage(Guid id)
        {
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return _converter.ModelToDto(package);
        }

        private bool PackageExists(Guid id)
        {
            return _context.Package.Any(e => e.Id == id);
        }
    }
}
