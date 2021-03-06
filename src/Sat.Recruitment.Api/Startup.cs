using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.DataAccess.DAOs.Abstractions;
using Sat.Recruitment.DataAccess.DAOs.Implementation.File;
using Sat.Recruitment.Services.Abstractions;
using Sat.Recruitment.Services.Implementations;

namespace Sat.Recruitment.Api
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
            RegisterDAOs(services);
            RegisterServices(services);
            services.AddControllers();
            services.AddSwaggerGen();
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionServices, TransactionServices>();
            services.AddScoped<IValidateServices, ValidateServices>();
        }

        private void RegisterDAOs(IServiceCollection services)
        {
            services.AddScoped<IUsersDAO, UsersDAO>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //AddSwagger(app);
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
