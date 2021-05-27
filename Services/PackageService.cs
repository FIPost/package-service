using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PakketService.Services
{
    public class PackageService : IPackageService
    {
        private readonly PackageServiceContext _context;
        private readonly IDtoConverter<Package, PackageRequest, PackageResponse> _converter;

        public PackageService(PackageServiceContext context, IDtoConverter<Package, PackageRequest, PackageResponse> converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<PackageResponse> AddAsync(PackageRequest request)
        {
            Package package = _converter.DtoToModel(request);
            // Make sure T&T equals package Id.
            package.TrackAndTraceId = package.Id;

            await _context.AddAsync(package);
            await _context.SaveChangesAsync();

            return _converter.ModelToDto(package);
        }

        public async Task<List<PackageResponse>> GetAllAsync()
        {
            return _converter.ModelToDto(await _context.Package.ToListAsync());
        }

        public async Task<PackageResponse> GetByIdAsync(Guid id)
        {
            Package package = await _context.Package.FirstOrDefaultAsync(e => e.Id == id);

            if (package == null)
            {
                throw new NotFoundException($"Package with id {id} not found.");
            }

            return _converter.ModelToDto(package);
        }

        public async Task<PackageResponse> UpdateAsync(Guid id, PackageRequest request)
        {
            Package package = _converter.DtoToModel(request);
            package.Id = id;

            if (!await _context.Package.AnyAsync(b => b.Id == id))
            {
                throw new NotFoundException($"Building with id {id} not found.");
            }

            _context.Update(package);
            await _context.SaveChangesAsync();

            return _converter.ModelToDto(package);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
