using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DAL.Models;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Models;

namespace Vehicle.Repository.Models
{
    public class SQLModelRepository : IVHModelRepository

    {
        VehicleDbContext _db;
        IMapper _mapper;
        IConfigurationProvider _cfg;
        public SQLModelRepository(VehicleDbContext db, IMapper mapper, IConfigurationProvider cfg)
        {
            _db = db;
            _mapper = mapper;
            _cfg = cfg;
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleModelAsync(int makeId)
        {

            var vehicleModel = await _db.VehicleModels.Where(x => x.MakeId == makeId).ToListAsync();
            if (vehicleModel == null)
            {
                throw new Exception("Not found");
            }

            return vehicleModel;

        }

        public async Task<VehicleModel> GetVehicleModelAsync(int? id)
        {
            var vehicleModel = await _db.VehicleModels
               .Include(v => v.VehicleMake)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel != null)
            {
                return vehicleModel;
            }
            throw new Exception("Not found");
        }

        public async Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel)
        {

            _db.Add(vehicleModel);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;
        }


        public async Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {

            _db.Update(vehicleModel);
            var numberOfChanges = await _db.SaveChangesAsync();
            return numberOfChanges;
        }

        public async Task<int> DeleteVehicleModelAsync(int? id)
        {
            var vehicleModel = await _db.VehicleModels.FindAsync(id);
            _db.VehicleModels.Remove(vehicleModel);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes
               .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Vehicle Make not found");
            }

            return vehicleMake;
        }

        public bool VehicleModelExists(int? id)
        {
            return _db.VehicleModels.Any(e => e.Id == id);
        }
    }
}
