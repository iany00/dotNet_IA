using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Resource;
using CarStore.Domain.Models;

namespace CarStore.API.Mapper
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Car, CarResource>();

            CreateMap<Car, CarResource>()
                .ForMember(src => src.Currency,
                    opt => opt.MapFrom(src => src.Currency.ToDescriptionString()));

            CreateMap<Car, CarResource>()
                .ForMember(src => src.EngineType,
                    opt => opt.MapFrom(src => src.EngineType.ToDescriptionString()));

            CreateMap<Car, CarResource>()
                .ForMember(src => src.FuelType,
                    opt => opt.MapFrom(src => src.FuelType.ToDescriptionString()));

            CreateMap<Car, CarResource>()
                .ForMember(src => src.SeatsAmount,
                    opt => opt.MapFrom(src => src.SeatsAmount.ToDescriptionString()));

            CreateMap<Car, CarResource>()
                .ForMember(src => src.TransmissionType,
                    opt => opt.MapFrom(src => src.TransmissionType.ToDescriptionString()));

            CreateMap<CarManufacturer, CarManufacturerResource>();

            CreateMap<Store, StoreResource>();
            
            CreateMap<User, UserResource>();
        }
    }
}
