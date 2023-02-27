using AutoMapper;
using Domain;

namespace Application.Core
{
    //To map the entities
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Where do we want to go from and where do we want to go to
            CreateMap<Activity, Activity>();
        }
    }
}