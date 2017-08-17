using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
  public  class OperatorWiseDriverVehicleAttachedTodayList :IContract
    {
        public string OperatorMobileNo { get; set; }
        public string DriverName { get; set; }
        public string DriverLicenseNo { get; set; }
        public string DriverMobileNo { get; set; }
        public string VehicleattachedNo { get; set; }
        public int VehicleType { get; set; }
        public int VehicleGroup { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
