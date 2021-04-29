using PakketService.Database.Datamodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public interface IPackageService
    {
        Task<Package> AddAsync(Package package);
        Task<List<Package>> GetAllAsync();
        Task<Package> GetByIdAsync(Guid id);
        Task<List<Package>> GetByReceiverIdAsync(Guid id);
        Task<List<Package>> GetByLocationIdAsync(Guid id);
        Task<Package> UpdateAsync(Guid id, Package package);
        Task<Package> DeleteByIdAsync(Guid id);
    }
}
