using LocatieService.Repositories;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Datamodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(PackageServiceContext context) : base(context) { }
        public async Task<List<Package>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Package> GetByIdAsync(Guid id)
        {
            return await GetAll().FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Package>> GetByLocationIdAsync(Guid id)
        {
            throw new NotImplementedException(); // This method will be implemented later.
            //return await GetAll().Where(b => b.Tickets.Last().ToDoLocationId == id.ToString()).ToListAsync();
        }

        public async Task<List<Package>> GetByReceiverIdAsync(Guid id)
        {
            return await GetAll().Where(b => b.ReceiverId == id).ToListAsync();
        }
    }
}
