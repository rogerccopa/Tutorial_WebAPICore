using DataStore.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IWebHostEnvironment env)
        {
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsDevelopment())
            {
                services.AddDbContext<BugsContext>(options =>
                {
                    // name our database "Bugs"
                    options.UseInMemoryDatabase("Bugs");
                });
            }

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BugsContext bugsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // create in-memory database for dev environment
                bugsContext.Database.EnsureDeleted();
                bugsContext.Database.EnsureCreated();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
