using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Paging;
using Vehicle.DAL.Models;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Models;

namespace Vehicle.Repository.Models
{
    public class SQLMakeRepository : IVHMakeRepository
    {
        VehicleDbContext _db;
        IMapper _mapper;
        AutoMapper.IConfigurationProvider _cfg;
        public SQLMakeRepository(VehicleDbContext db, IMapper mapper, AutoMapper.IConfigurationProvider cfg)
        {
            _db = db;
            _mapper = mapper;
            _cfg = cfg;
        }

        public IQueryable<VehicleMake> GetVehicleMakesPaged(IVehicleMakePaging queryParams)
        {
            var query = _db.VehicleMakes.AsQueryable();
            if (!string.IsNullOrEmpty(queryParams.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParams.Search));
            }

            return query;
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

        public async Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake)
        {

            _db.Add(vehicleMake);
            var numberOfCreated = await _db.SaveChangesAsync();
            return numberOfCreated;

        }


        public async Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {

            _db.Update(vehicleMake);
            var numberOfChanges = await _db.SaveChangesAsync();

            return numberOfChanges;
        }

        public bool VehicleMakeExists(int id)
        {
            return _db.VehicleMakes.Any(e => e.Id == id);
        }

        public async Task<int> DeleteVehicleMakeAsync(int? id)
        {
            var vehicleMake = await _db.VehicleMakes.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleMake == null)
            {
                throw new Exception("Not found");
            }

            _db.VehicleMakes.Remove(vehicleMake);
            var numberOfDeleted = await _db.SaveChangesAsync();
            return numberOfDeleted;

        }
    }

}
