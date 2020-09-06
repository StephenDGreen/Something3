using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Something3.API.Services;
using Something3.Core;
using Something3.Core.Services;
using Something3.Database;
using Something3.Database.Services;

namespace Something3.API
{
    public class Startup
    {
        readonly string DevSomething3AllowSpecificOrigins = "_devSomething3AllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: DevSomething3AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:44380")
                                      .AllowAnyMethod().AllowAnyHeader();
                                  });
            });
            services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase(nameof(Something3.API))
                );
            services.AddSingleton<ISomething3Factory, Something3Factory>();
            services.AddScoped<ISomething3Interactor, Something3Interactor>();
            services.AddScoped<ISomething3DisplayInteractor, Something3DisplayInteractor>();
            services.AddScoped<IClassLibraryPersistence, ClassLibraryPersistence>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors(DevSomething3AllowSpecificOrigins);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
