using LocatieService.Repositories;
using PakketService.Database.Datamodels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PakketService.Repositories
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task<Package> GetByIdAsync(Guid id);
        Task<List<Package>> GetByReceiverIdAsync(Guid id);
        Task<List<Package>> GetByLocationIdAsync(Guid id);
        Task<List<Package>> GetAllAsync();
    }
}
