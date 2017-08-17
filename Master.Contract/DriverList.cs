using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
  public  class DriverList :IContract
    {
        public DriverList() {}

        public string DriverID { get; set; }

        public string DriverName { get; set; }
    }
}
