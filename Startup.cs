using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WhaleExtApi.Database;
using WhaleExtApi.Repositories;
using WhaleExtApi.Services;

namespace WhaleExtApi
{
    public class Startup
    {
        private readonly string AllowAnyOriginPolicy = "_allowAnyOrigin";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                name: AllowAnyOriginPolicy,
                builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WhaleExtApi", Version = "v1" });
            });

            services.AddTransient<ApiDbContext>();

            services.AddTransient<ILocationsRepo, LocationsRepo>();
            services.AddTransient<ISightingsRepo, SightingsRepo>();
            services.AddTransient<ISpeciesRepo, SpeciesRepo>();

            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<ISightingsService, SightingsService>();
            services.AddTransient<ISpeciesService, SpeciesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhaleExtApi v1"));
            }
            
            app.UseCors(AllowAnyOriginPolicy);

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
