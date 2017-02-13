using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickC.Internal.ViewModals
{
    public class DriverAttachments
    {
        public string driverId { get; set; }
        public string lookupCode { get; set; }
        public HttpPostedFile imagePath { get; set; }
    }
}