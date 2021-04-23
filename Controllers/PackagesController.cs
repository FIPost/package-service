﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
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

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<List<PackageResponse>>> GetPackage()
        {
            return _converter.ModelToDto(await _service.GetAllPackagesAsync());
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponse>> GetPackage(Guid id)
        {
            return _converter.ModelToDto(await _service.GetPackageByIdAsync(id));
        }

        // GET: api/Packages/Receiver/5
        [HttpGet("Receiver/{id}")]
        public async Task<ActionResult<List<PackageResponse>>> GetPackagesByReceiverId(Guid id)
        {
            return _converter.ModelToDto(await _service.GetPackageByReceiverIdAsync(id));
        }

        // GET: api/Packages/Location/5
        [HttpGet("Location/{id}")]
        public async Task<ActionResult<List<PackageResponse>>> GetPackagesBylocationId(Guid id)
        {
            return _converter.ModelToDto(await _service.GetPackageByLocationIdAsync(id));
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<ActionResult<PackageResponse>> PutPackage(Package package)
        {
            return _converter.ModelToDto(await _service.UpdatePackageAsync(package));
        }

        // POST: api/Packages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PackageResponse>> PostPackage(PackageRequest dto)
        {
            return _converter.ModelToDto(await _service.AddPackageAsync(_converter.DtoToModel(dto)));
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackageResponse>> DeletePackage(Guid id)
        {
            return _converter.ModelToDto(await _service.DeletePackageByIdAsync(id));
        }
    }
}
