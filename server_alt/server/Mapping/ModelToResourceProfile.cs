using AutoMapper;
using server.Models;
using server.Resources;

namespace server.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Data, DataResource>();
        }
    }
}