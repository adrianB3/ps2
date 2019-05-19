using AutoMapper;
using server.Models;
using server.Resources;

namespace server.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDataResource, Data>();
        }
    }
}