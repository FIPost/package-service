using PakketService.Database.Datamodels;
using PakketService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _repository;

        public PackageService(IPackageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Package> AddPackageAsync(Package package)
        {
            // Make sure T&T equals package Id.
            package.TrackAndTraceId = package.Id;
            return await _repository.AddAsync(package);
        }

        public async Task<Package> DeletePackageByIdAsync(Guid id)
        {
            Package package = await GetPackageByIdAsync(id);
            return await _repository.DeleteAsync(package);
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Package> GetPackageByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Package>> GetPackageByLocationIdAsync(Guid id)
        {
            return await _repository.GetByLocationIdAsync(id);
        }

        public async Task<List<Package>> GetPackageByReceiverIdAsync(Guid id)
        {
            return await _repository.GetByReceiverIdAsync(id);
        }

        public async Task<Package> UpdatePackageAsync(Package package)
        {
            return await _repository.UpdateAsync(package);
        }
    }
}
