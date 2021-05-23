﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Paging;
using Vehicle.DAL.Models;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Models
{
    public interface IVHMakeRepository
    {
        IQueryable<VehicleMake> GetVehicleMakesPaged(IVehicleMakePaging queryParams);
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        bool VehicleMakeExists(int id);
        Task<int> DeleteVehicleMakeAsync(int? id);
    }
}
