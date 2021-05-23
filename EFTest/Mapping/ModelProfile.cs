using AutoMapper;
using Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {

            CreateMap<VehicleModel, CreateModel>();
            CreateMap<CreateModel, VehicleModel>();

            CreateMap<VehicleModel, IndexModel>();
            CreateMap<IndexModel, VehicleModel>();

            CreateMap<VehicleModel, DetailsModel>();
            CreateMap<DetailsModel, VehicleModel>();

            CreateMap<VehicleModel, EditModel>();
            CreateMap<EditModel, VehicleModel>();

            CreateMap<VehicleModel, DeleteModel>();
            CreateMap<DeleteModel, VehicleModel>();


        }
    }
}
