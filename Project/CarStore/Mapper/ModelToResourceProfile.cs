using AutoMapper;
using CarStore.API.Resource;
using CarStore.Domain.Models;

namespace CarStore.API.Mapper
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Car, CarResource>();
        }
    }
}
