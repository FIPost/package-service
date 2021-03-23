using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Datamodels;

namespace PakketService.Database.Contexts
{
    public class PackageServiceContext : DbContext
    {
        public PackageServiceContext (DbContextOptions<PackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Package { get; set; }
    }
}