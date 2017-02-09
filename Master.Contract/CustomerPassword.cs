using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master.Contract;
namespace Master.Contract
{
    public class CustomerPassword : IContract
    {
        public string MobileNo { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

    }
}
