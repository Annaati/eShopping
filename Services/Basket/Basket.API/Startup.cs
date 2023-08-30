using Basket.Application.Commands;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Basket.API
{
    public class Startup
    {
        public IConfiguration _config;
        public Startup(IConfiguration config)
        {
            this._config = config;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = _config.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddMediatR(typeof(UpdatehoppingBasketCommand).GetTypeInfo().Assembly);
            services.AddScoped<IShoppingBasketRepository, ShoppingBasketRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket API", Version = "v1" });
            });

            services.AddHealthChecks().AddRedis(
                _config["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket API v1"));
            }


            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }



    }
}
