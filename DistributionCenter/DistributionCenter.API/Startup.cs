using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DistributionCenter.API.Middlewares;
using DistributionCenter.Core.Interfaces.Profiles.MapperProfiles;
using DistributionCenter.Core.Profiles.MapperProfiles;
using DistributionCenter.DAL.MSSQL;
using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using DistributionCenter.API.Configurations.Swagger;
using DistributionCenter.Core;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using Serilog;
using DistributionCenter.API.Configurations.Serilog;
using DistributionCenter.Core.Interfaces.Entities;
using DistributionCenter.API.Configurations;

namespace DistributionCenter.API
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
                services.AddDbContext<AppDbMSSQLContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionString")));
                Log.Information("Storage: Using MSSQLServer Db");
            }
            else
            {
                services.AddDbContext<AppDbMSSQLContext>(option =>
                     option.UseInMemoryDatabase("InMemoryDb"));
                Log.Information($"Storage: Using InMemory Db");
            }

            //services.AddSingleton<IMessageBusClient, MessageBusClient>();
            //services.AddGrpc();
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

            // DI
            DependencyInjectionConfiguration register = new DependencyInjectionConfiguration(Configuration);
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
    internal class DependencyInjectionConfiguration : BaseDependencyInjectionConfiguration
    {
        public DependencyInjectionConfiguration(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void RegisterConfigs(ref IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IAppDbInitializer, AppDbMSSQLInitializer>();
            services.AddSingleton(DataMapperProfile.GetMapper());
            services.AddScoped<IDataMapper, DataMapper>();
        }
    }
}
