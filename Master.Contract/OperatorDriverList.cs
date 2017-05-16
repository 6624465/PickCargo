using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
  public  class OperatorDriverList : IContract
    { 
        public string OperatorDriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverLicenseNo { get; set; }
        public string DriverMobileNo { get; set; }
        public string VehicleattachedNo { get; set; }       
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
