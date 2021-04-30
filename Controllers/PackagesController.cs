using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.Services;

namespace PakketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _service;
        private readonly IDtoConverter<Package, PackageRequest, PackageResponse> _converter;

        public PackagesController(IPackageService service, IDtoConverter<Package, PackageRequest, PackageResponse> converter)
        {
            _service = service;
            _converter = converter;
        }

        // POST: api/Packages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PackageResponse>> AddPackage(PackageRequest request)
        {
            return _converter.ModelToDto(await _service.AddAsync(_converter.DtoToModel(request)));
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<List<PackageResponse>>> GetAllPackages()
        {
            return _converter.ModelToDto(await _service.GetAllAsync());
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponse>> GetPackageById(Guid id)
        {
            return _converter.ModelToDto(await _service.GetByIdAsync(id));
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<PackageResponse>> UpdatePackage(Guid id, PackageRequest request)
        {
            return _converter.ModelToDto(await _service.UpdateAsync(id, _converter.DtoToModel(request)));
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackageResponse>> DeletePackageById(Guid id)
        {
            return _converter.ModelToDto(await _service.DeleteByIdAsync(id));
        }
    }
}
