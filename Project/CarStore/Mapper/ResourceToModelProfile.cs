using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.Domain.Models;
using CarStore.Resource;

namespace CarStore.Mapper
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCarResource, Car>();
        }
        
    }
}
