using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // < from , to >
            CreateMap<Activity, Activity>();
        }
    }
}