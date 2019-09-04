using AutoMapper;
using AspNetCore.Bookstore.Application.AutoMapper.Profiles;

namespace AspNetCore.Bookstore.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToCommandProfile());
            });
            return mapperConfiguration;
        }
    }
}