using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace NovoProjeto.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup( this IServiceCollection services )
        {
            services.AddAutoMapper( typeof( DomainToViewEntityMappingProfile ), typeof( ViewEntityToDomainMappingProfile ) );

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
