using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PakketService.Database.Contexts;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.Services;

namespace PakketService
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TO DO: connection hard-coded for testing (should be changed later)
            var connection = Configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<PackageServiceContext>(
                options => options.UseSqlServer(connection));

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                builder =>
                {
                        builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                    });
            });

            //Inject converter.
            services.AddScoped<IDtoConverter<Package, PackageRequest, PackageResponse>, DtoConverter>();

            // Inject services.
            services.AddTransient<IPackageService, PackageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PackageServiceContext context)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PakketService");
                // Serve the swagger UI at the app's root
                c.RoutePrefix = string.Empty;
            });
        }
    }
}