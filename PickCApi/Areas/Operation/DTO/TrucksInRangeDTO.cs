using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickCApi.Areas.Operation.DTO
{
    public class TrucksInRangeDTO
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public short vehicleType { get; set; }

        public short vehicleGroup { get; set; }
    }
}