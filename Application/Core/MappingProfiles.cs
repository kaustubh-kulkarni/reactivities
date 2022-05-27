using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //map from - map to
            CreateMap<Activity, Activity>();
        }
    }
}