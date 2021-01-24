using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Services;
using RealEstate.Services.Interfaces;
using System;

namespace RealEstate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<RealEstateContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RealEstate")));
                       
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IPropertyCategoryService, PropertyCategoryService>();

            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPropertyCategoryRepository, PropertyCategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
