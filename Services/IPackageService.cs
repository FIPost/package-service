using PakketService.Database.Datamodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public interface IPackageService
    {
        Task<Package> AddPackageAsync(Package package);
        Task<List<Package>> GetAllPackagesAsync();
        Task<Package> GetPackageByIdAsync(Guid id);
        Task<List<Package>> GetPackageByReceiverIdAsync(Guid id);
        Task<List<Package>> GetPackageByLocationIdAsync(Guid id);
        Task<Package> UpdatePackageAsync(Package package);
        Task<Package> DeletePackageByIdAsync(Guid id);
    }
}
