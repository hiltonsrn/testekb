using Kanban.Application;
using Kanban.Domain.Entities;
using Kanban.Infra.Data.Contexts;
using Kanban.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KanbanContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Kanban")));
            Injector.Register(services);
            services.AddAutoMapper(x => x.AddProfile(new MappingEntities()));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
