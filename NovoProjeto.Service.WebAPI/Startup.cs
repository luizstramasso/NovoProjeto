using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using NovoProjeto.Infra.CrossCutting.IoC;
using NovoProjeto.Infra.CrossCutting.Util.HelpEntity.AppSettings;
using System;
using System.IO;

namespace NovoProjeto.Service.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup( IWebHostEnvironment environment )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( environment.ContentRootPath )
                .AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
                .AddJsonFile( $"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true )
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.Configure<Configuration>( Configuration.GetSection( "Configuration" ) );

            var configuration = Configuration.GetSection( "Configuration" ).Get<Configuration>();

            services.NovoProjetoSetup( typeof( Startup ) );
            services.AddControllers();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NovoProjeto API",
                    Description = "Projeto de portifólio, usando DDD, Repository, IoC, Swagger, entre outros",
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Stramasso",
                        Email = "luizstramasso@gmail.com",
                        Url = new Uri( "https://luizstramasso.github.io/" ),
                    }
                } );
                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                var appName = PlatformServices.Default.Application.ApplicationName;
                var xmlPath = Path.Combine( appPath, $"{appName}.xml" );

                c.IncludeXmlComments( xmlPath );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "NovoProjeto v1" ) );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
