using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Desarrollo.Store.API.Models.Common;
using PruebaTecnica.Desarrollo.Store.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Store.API
{
    public class Startup
    {
        readonly string cuscomCor = "CustomCor";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Cofig Services.
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFacturaService, FacturaService>();

            // Cofig Cors.
            services.AddCors(options =>
            {
                options.AddPolicy(name: cuscomCor,
                                  builder=>{
                                      // sin esta línea da problemas cunado se insertan datos.
                                      builder.WithHeaders("*");
                                      // Valida desde donde va a permitir ser cosumido el servicio.
                                      builder.WithOrigins("*");
                                      // Permite que se ejecuten todos los métodos Http.
                                      builder.WithMethods("*");
                                  });
            });

            // Config Autenticación JWT.
            // Obtengo la Seccion del archivo appsettings.json y lleno la clase con los datos que tiene.
            var globalValues = Configuration.GetSection("GlobalValues");
            services.Configure<GlobalValues>(globalValues);

            var optGlobalValues = globalValues.Get<GlobalValues>();
            var key = Encoding.ASCII.GetBytes(optGlobalValues.SecretKey);

            // Microsoft.AspNetCore.Authentication.JwtBearer --> pkg para poder utilizar el token.
            // con la versión en 3,dao que se esta trabajando en Net Core 3.1.
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(j =>
            {
                j.RequireHttpsMetadata = false;
                j.SaveToken = true;
                j.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(cuscomCor);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
