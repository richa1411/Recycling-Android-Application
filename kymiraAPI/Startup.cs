using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using kymiraAPI.Models;
using kymiraAPI.Fixtures;

namespace kymiraAPI
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
            services.AddMvc();

            services.AddDbContext<kymiraAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("kymiraAPIContext")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,kymiraAPIContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            context.Database.EnsureCreated();
            Fixtures.fixture_resident.delete(context);
            Fixtures.fixture_resident.load(context);
          //  Fixtures.fixture_faq.delete(context);
            Fixtures.fixture_faq.load(context);
            app.UseMvc();
        }
    }
}
