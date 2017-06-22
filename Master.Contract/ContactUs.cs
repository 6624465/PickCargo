using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
    public class ContactUs : IContract
    {
        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Mobile
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }
    }
}
