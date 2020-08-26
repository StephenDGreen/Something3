using ClassLibrary1.Application.Services;
using ClassLibrary1.Core;
using ClassLibrary1.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Something3.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase(nameof(Something3.UI))
                );
            services.AddSingleton<ISomething3Factory, Something3Factory>();
            services.AddScoped<ISomething3Interactor,Something3Interactor>();
            services.AddScoped<ISomething3DisplayInteractor,Something3DisplayInteractor>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
