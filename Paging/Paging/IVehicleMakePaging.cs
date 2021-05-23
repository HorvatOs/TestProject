using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Api.Paging
{
    public interface IVehicleMakePaging
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
    }
}
