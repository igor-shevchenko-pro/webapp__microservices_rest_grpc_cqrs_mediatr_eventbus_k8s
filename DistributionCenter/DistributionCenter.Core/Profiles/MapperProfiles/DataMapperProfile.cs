using AutoMapper;
using DistributionCenter.API.Resources;
using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Resources;

namespace DistributionCenter.Core.Profiles.MapperProfiles
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            // Platform
            CreateMap<Platform, PlatformGetResource>();

            // Server
            CreateMap<Server, ServerGetResource>();
        }

        public static IMapper GetMapper()
        {
            var mapplineConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataMapperProfile());
            });

            IMapper mapper = mapplineConfig.CreateMapper();

            return mapper;
        }
    }
}
