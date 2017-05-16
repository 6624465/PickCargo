using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Master.Contract;

namespace Master.Contract
{
    public class Driver : IContract
    {
        public Driver() { }


        public string DriverID { get; set; }


        public string DriverName { get; set; }

        public string Password { get; set; }

        public string VehicleNo { get; set; }

        public string VehicleType { get; set; }

        public string FatherName { get; set; }


        public DateTime DateOfBirth { get; set; }


        public string PlaceOfBirth { get; set; }


        public Int16 Gender { get; set; }

        public string GenderDescription { get; set; }


        public Int16 MaritialStatus { get; set; }


        public string MaritialStatusDescription { get; set; }

        public string MobileNo { get; set; }


        public string PhoneNo { get; set; }


        public string PANNo { get; set; }


        public string AadharCardNo { get; set; }


        public string LicenseNo { get; set; }


        public bool Status { get; set; }


        public string CreatedBy { get; set; }


        public DateTime CreatedOn { get; set; }


        public string ModifiedBy { get; set; }


        public DateTime ModifiedOn { get; set; }


        public bool IsVerified { get; set; }


        public string VerifiedBy { get; set; }

        public string DeviceID { get; set; }


        public DateTime VerifiedOn { get; set; }

        public List<Address> AddressList { get; set; }

        public string Nationality { get; set; }

        public List<BankDetails> BankDetails { get; set; }
    }
}




