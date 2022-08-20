using Customers.Api;
using Customers.Api.Services;
using Customers.Api.Services.Interface;
using Customers.Data;
using Customers.Data.Dto;
using Customers.Data.Interface;
using Customers.Data.Repository;
using Dapper.FastCrud;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mapping = Customers.Api.Mapping;

namespace customers.api
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
            new DatabaseEntities().RegisterDapperEntities();

            services.Configure<RouteOptions>(o => o.LowercaseUrls = true);
            services.AddControllers()
                .AddJsonOptions(o =>
                {
                    var camelCaseConverter = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
                    o.JsonSerializerOptions.Converters.Add(camelCaseConverter);
                });
                
            services.AddSwaggerGen();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(Mapping.Customer)));

            var options = new ConfigOptions
            {
                ConnectionString = Configuration.GetConnectionString("db-customers")
            };
            services.Configure<ConfigOptions>(o => o.ConnectionString = Configuration.GetConnectionString("db-customers"));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IGenericService<,>), typeof(GenericService<,>));

            services.AddScoped<ICustomerRepository<CustomerDto>, CustomerRepository<CustomerDto>>();
            services.AddScoped<ICustomerNoteRepository<CustomerNoteDto>, CustomerNoteRepository<CustomerNoteDto>>();

            services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
