using CommandCenter.API.Configurations.Serilog;
using CommandCenter.API.Configurations.Swagger;
using CommandCenter.API.Middlewares;
using CommandCenter.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using CommandCenter.DAL.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using CommandCenter.Core.Interfaces.Entities;
using MediatR;
using CommandCenter.Core.Interfaces.Profiles.MapperProfiles;
using CommandCenter.Core.Profiles.MapperProfiles.DataMapper;
using CommandCenter.API.Configurations;

namespace CommandCenter.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
            {
                services.AddDbContext<AppDbPostgreSQLContext>(option =>
                    option.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnectionString")));
                Log.Information("Storage: Using PostgreSQL Db");
            }
            else
            {
                services.AddDbContext<AppDbPostgreSQLContext>(option =>
                     option.UseInMemoryDatabase("InMemoryDb"));
                Log.Information($"Storage: Using InMemory Db");
            }

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
                options.RespectBrowserAcceptHeader = true;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = ApiVersion.Default;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader(Constants.HttpContextHeaderKeys.API_VERSION),
                    new HeaderApiVersionReader(Constants.HttpContextHeaderKeys.API_VERSION)
                );
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
            });
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
                options.ResolveConflictingActions(descriptions => { return descriptions.First(); });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(Startup));
            services.AddSignalR();

            // DI
            DependencyInjectionConfigurationBase register = new DependencyInjectionConfigurationBase(Configuration);
            register.RegisterAll(ref services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRequestCorrelationId();
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = LogHelper.EnrichFromRequest;
            });
            app.UseExceptionHandlingMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGrpcService<GrpcPlatformService>();

                //endpoints.MapGet("/protos/platforms.proto", async context =>
                //{
                //    await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
                //});
            });

            InitializeDb(app);
        }

        /// <summary>
        /// Create the database if it does not already exist
        /// Applies any pending migrations for the context to the database
        /// Adds some default values to the Db
        /// </summary>
        /// <param name="app"></param>
        private void InitializeDb(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetService<IAppDbInitializer>();

                if (_env.IsProduction())
                {
                    dbInitializer?.Initialize();
                }

                dbInitializer?.SeedData();
            }
        }
    }

    /// <summary>
    /// Mechanism of DependencyInjection registration moved from Startup to this class 
    /// It allows to have more complexity and flexibility operating with DI registration
    /// </summary>
    internal class DependencyInjectionConfigurationBase : DependencyInjectionConfiguration
    {
        public DependencyInjectionConfigurationBase(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public override void RegisterConfigs(ref IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IAppDbInitializer, AppDbPostgreSQLInitializer>();
            services.AddSingleton(DataMapperProfile.GetMapper());
            services.AddScoped<IDataMapper, DataMapper>();
        }
    }
}
