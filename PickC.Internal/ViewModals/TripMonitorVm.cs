using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickC.Internal.ViewModals
{
    public class TripMonitorVm
    {
        public Address address { get; set; }
        public string title { get; set; }
    }

    public class Address
    {
        public string address { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }    
}