using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model.Common.Models;



namespace Vehicle.Model.Models
{
    public class VehicleMake : IVehicleMake
    {
        public VehicleMake()
        {
            VehicleModels = new HashSet<VehicleModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
