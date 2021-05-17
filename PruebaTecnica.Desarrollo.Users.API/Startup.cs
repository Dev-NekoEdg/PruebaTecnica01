using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PruebaTecnica.Desarrollo.Users.API.Infrastructure.Mapper;
using PruebaTecnica.Desarrollo.Users.API.Infrastructure.Services;
using PruebaTecnica.Desarrollo.Users.API.Models;
using PruebaTecnica.Desarrollo.Users.Domain.IRepository;
using PruebaTecnica.Desarrollo.Users.Infrastructure;
using PruebaTecnica.Desarrollo.Users.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API
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
            // Config DB.
            services.AddDbContext<UsersContext>(
                opt => opt.UseSqlServer(
                                Configuration.GetConnectionString("DbConnection"),
                                b => b.MigrationsAssembly("PruebaTecnica.Desarrollo.Users.API")
                                )
                );

            // Config Clase de valores.
            services.Configure<GlobalConfig>(Configuration.GetSection("globalConfig"));

            // Config Dependency Injection.
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IExternalUserRepository, ExternalUserRepository>();
            services.AddTransient<ICustomAuthentication, CustomAuthentication>();

            // Config Mapper.
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            // Config JWT.
            // Se obtiene el array de bytes de la llave secreta.
            var key = Encoding.ASCII.GetBytes(Configuration["globalConfig:secretKey"]);

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

            // Config swagger.
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v2/swagger.json", "Prueba Técnica Desarrollo");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Método para agragar la firma de Swagger.
        /// </summary>
        /// <param name="services">Coleccion de Servicios.</param>
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo
                {

                    Title = "Prueba técnica Desarrollo",
                    Version = "v2",
                    Description = "prueba técnica backend para la empresa Desarrollo",
                    Contact = new OpenApiContact
                    {
                        Name = "Edgard Alvarado",
                        Email = "edg.Alvarado@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/dev-nekoedg/")
                    }
                });
            });
        }
    }
}
