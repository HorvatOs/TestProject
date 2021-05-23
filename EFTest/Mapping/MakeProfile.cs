using AutoMapper;
using Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Mapping
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {

            CreateMap<VehicleMake, CreateMake>();
            CreateMap<CreateMake, VehicleMake>();

            CreateMap<VehicleMake, DetailsMake>();
            CreateMap<DetailsMake, VehicleMake>();

            CreateMap<VehicleMake, DeleteMake>();
            CreateMap<DeleteMake, VehicleMake>();

            CreateMap<VehicleMake, EditMake>();
            CreateMap<EditMake, VehicleMake>();

            CreateMap<VehicleMake, IndexMake>();
            CreateMap<IndexMake, VehicleMake>();
        }
    }
}

