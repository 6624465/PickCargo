using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
    public class OperatorDriverTruckAttachment : IContract
    {
        public string DriverID { get; set; }
        public string VehicleNo { get; set; }
        public string OperatorMobNo { get; set; }       
        public bool Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
