using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Model.Models;

namespace Vehicle.Model.Common.Models
{
    public interface IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
