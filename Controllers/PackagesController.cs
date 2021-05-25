using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.helpers;
using PakketService.Services;

namespace PakketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _service;

        public PackagesController(IPackageService service)
        {
            _service = service;
        }

        // POST: api/Packages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PackageResponse>> AddPackage(PackageRequest request)
        {
            return await _service.AddAsync(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<PackageResponse>>> GetAllPackages()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponse>> GetPackageById(Guid id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<PackageResponse>> UpdatePackage(Guid id, PackageRequest request)
        {
            try
            {
                return Ok(await _service.UpdateAsync(id, request));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("health")]
        public ActionResult Health()
        {
            return Ok();
        }
    }
}
