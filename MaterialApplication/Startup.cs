using System;
using AutoMapper;
using Material.API.Api;
using Material.Core.Middlewares;
using Material.Core.Repository;
using Material.Core.Services;
using Material.Data.Configs;
using Material.Data.Repository;
using Material.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Material.API
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
            services.AddControllers();
            services.Configure<RavenSettings>(Configuration.GetSection("Raven"));
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IMaterialServices, MaterialServices>();

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(option =>
            {
                var xmlDocPath = $"{AppContext.BaseDirectory}Api.xml";
                option.IncludeXmlComments(xmlDocPath, true);

                option.EnableAnnotations();

                option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
