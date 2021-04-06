using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Services;
using SICSinop.Infrastructure.Data.Context;
using SICSinop.Domain.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICSinop.API
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
            // Authentication
            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

            // MSSQL
            //services.AddDbContext<MainDbContext>(
            //    options => options.UseSqlServer(
            //        Configuration.GetConnectionString("MainConnection"),
            //        x => x.MigrationsAssembly("SICSinop.Infrastructure")));

            services.AddControllers();

            services.AddEntityFrameworkNpgsql()
             .AddDbContext<MainDbContext>(
                options => options.UseNpgsql(
                    Configuration.GetConnectionString("PostgreSQL"),
                    x => x.MigrationsAssembly("SICSinop.Infrastructure")
                    )
                );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMarkerRepository, MarkerRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMarkerService, MarkerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
