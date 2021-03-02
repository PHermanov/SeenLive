using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SeenLive.Infrastructure;
using SeenLive.Persistence.Contexts;
using SeenLive.Persistence.Repositories;
using SeenLive.Persistence.Repositories.Bands;

namespace SeenLive.Web
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
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<HandlerBase>());

            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBandRepository, BandRepository>();

            ////services.AddMvcCore()
            ////    .AddApiExplorer()
            ////    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<>());

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "SeenLive API" });
            });

            services.AddMediatR(Assembly.GetAssembly(typeof(BaseRepository)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "SeenLive/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/SeenLive/swagger/v1/swagger.json", "SeenLive API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
