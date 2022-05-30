using AutoMapper;
using CommandCenter.Core.Entities;
using CommandCenter.Core.Resources;

namespace CommandCenter.Core.Profiles.MapperProfiles.DataMapper
{
    public class DataMapperProfile : Profile
    {
        public static IMapper GetMapper()
        {
            var mapplineConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataMapperProfile());
            });

            IMapper mapper = mapplineConfig.CreateMapper();

            return mapper;
        }

        public DataMapperProfile()
        {
            // Framework
            CreateMap<Framework, FrameworkGetResource>();

            // Protocol
            CreateMap<Protocol, ProtocolGetResource>();
        }
    }
}
