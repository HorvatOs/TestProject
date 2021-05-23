using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model.Models;

namespace Vehicle.Repository.Common.Models
{
    public interface IVHModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelAsync(int makeId);
        Task<VehicleModel> GetVehicleModelAsync(int? id);
        Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel);

        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<int> DeleteVehicleModelAsync(int? id);
        Task<VehicleMake> GetVehicleMakeAsync(int? id);
        bool VehicleModelExists(int? id);

    }
}
