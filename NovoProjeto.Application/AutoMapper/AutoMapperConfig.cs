using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NovoProjeto.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup( this IServiceCollection services, Type type )
        {
            services.AddAutoMapper( type );

            RegisterMappings();
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration( cfg =>
             {
                 cfg.AddProfile( new DomainToViewEntityMappingProfile() );
                 cfg.AddProfile( new ViewEntityToDomainMappingProfile() );
             } );
        }
    }
}
