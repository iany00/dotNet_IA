using AutoMapper;
using CarStore.API.Resource;
using CarStore.Domain.Models;

namespace CarStore.API.Mapper
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCarResource, Car>();
            CreateMap<SaveCarManufacturerResource, CarManufacturer>();
            CreateMap<SaveStoreResource, Store>();
            CreateMap<SaveUserResource, User>();
        }
        
    }
}
