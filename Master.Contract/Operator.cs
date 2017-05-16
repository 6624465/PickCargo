using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Master.Contract;

namespace Master.Contract
{
 public class Operator :IContract
    {
        public Operator() {}

        public string OperatorID { get; set; }

        public string OperatorName { get; set; }

        public string Password { get; set; }

        public string FatherName { get; set; }

        public Int16 Gender { get; set; }

        public bool Status { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public Int16 MaritialStatus { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        public string PANNo { get; set; }

        public string AadharCardNo { get; set; }   
            
        public bool IsVerified { get; set; }

        public string VerifiedBy { get; set; }

        public DateTime VerifiedOn { get; set; }

        public string Nationality { get; set; }

        //public string GenderDescription { get; set; }

        public List<Address> AddressList { get; set; }

        public List<BankDetails> BankDetails { get; set; }

        public List<OperatorDriverList> OperatorDriverList { get; set; }
        public List<OperatorVehicle> OperatorVehicle { get; set; }
    }
}
