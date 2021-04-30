using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Datamodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public class PackageService : IPackageService
    {
        private readonly PackageServiceContext _context;

        public PackageService(PackageServiceContext context)
        {
            _context = context;
        }

        public async Task<Package> AddAsync(Package package)
        {
            // Make sure T&T equals package Id.
            package.TrackAndTraceId = package.Id;

            await _context.AddAsync(package);
            await _context.SaveChangesAsync();

            return package;
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Package.ToListAsync();
        }

        public async Task<Package> GetByIdAsync(Guid id)
        {
            Package package = await _context.Package.FirstOrDefaultAsync(e => e.Id == id);

            if (package == null)
            {
                throw new Exception($"Package with id {id} not found.");
            }

            return package;
        }

        public async Task<List<Package>> GetByReceiverIdAsync(Guid id)
        {
            List<Package> packages = await _context.Package.Where(b => b.ReceiverId == id).ToListAsync();

            if (packages == null)
            {
                throw new Exception($"Package with receiver id {id} not found.");
            }

            return packages;
        }

        public async Task<List<Package>> GetByLocationIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Package> UpdateAsync(Guid id, Package package)
        {
            package.Id = id;

            _context.Update(package);
            await _context.SaveChangesAsync();

            return package;
        }

        public async Task<Package> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
