using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.PlatformAbstractions;

namespace Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SchemaFilter<SwaggerExcludePropertiesFilter>();
                options.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "Desafio Técnico Capgemini",
                        Version = "v1",
                        Description = "Projeto de demonstração de desafio técnico Capgemini em .NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Cleiton da S. Mendonça",
                            Url = new Uri("https://github.com/cleitonmendonca/")
                        },
                        //License = new OpenApiLicense
                        //{
                        //    Url = new Uri("https://cleiton.mendonca"),
                        //    Name = ""
                        //},
                        //TermsOfService = new Uri("https://github.com/cleitonmendonca/term.md")
                        
                    });

                SetXmlDocumentation(options);
            });
        }

        private static void SetXmlDocumentation(SwaggerGenOptions options)
        {
            var xmlDocumentPath = GetXmlDocumentPath();
            var existsXmlDocument = File.Exists(xmlDocumentPath);

            if (existsXmlDocument)
            {
                options.IncludeXmlComments(xmlDocumentPath);
            }
        }

        private static string GetXmlDocumentPath()
        {
            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationName = PlatformServices.Default.Application.ApplicationName;
            return Path.Combine(applicationBasePath, $"{applicationName}.xml");
        }
    }
}
