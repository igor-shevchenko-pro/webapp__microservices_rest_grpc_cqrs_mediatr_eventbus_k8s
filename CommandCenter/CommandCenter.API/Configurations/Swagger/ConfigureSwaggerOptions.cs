using CommandCenter.Core;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CommandCenter.API.Configurations.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = Constants.SwaggerConfigurations.TITLE,
                Description = Constants.SwaggerConfigurations.DESCRIPTION,
                Version = description.ApiVersion.ToString(),
                TermsOfService = new Uri(Constants.SwaggerConfigurations.TERMS_OF_SERVICE_URL),
                License = new OpenApiLicense()
                {
                    Name = Constants.SwaggerConfigurations.LICENSE_NAME
                },
                Contact = new OpenApiContact()
                {
                    Name = Constants.SwaggerConfigurations.CONTACT_NAME,
                    Email = Constants.SwaggerConfigurations.CONTACT_EMAIL,
                    Url = new Uri(Constants.SwaggerConfigurations.CONTACT_URL)
                },
            };

            if (description.IsDeprecated)
            {
                info.Description += " *** This API version has been deprecated ***";
            }

            return info;
        }
    }
}
