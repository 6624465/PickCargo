using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
    public class OperatorVehicle : IContract
    {
        public string OperatorVehicleID { get; set; }
        public string VehicleRegistrationNo { get; set; }
        public string VehicleType { get; set; }
        public string Model { get; set; }
        public string Tonnage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
