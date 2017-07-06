using System;
using System.Collections.Generic;
using Master.Contract;
using Master.DataFactory;
using Operation.Contract;

namespace Master.BusinessFactory
{
    public class CustomerBO
    {
        private CustomerDAL customerDAL;
        public CustomerBO()
        {
            customerDAL = new CustomerDAL();
        }

        public bool UpdateCustomerPassword(CustomerPassword item)
        {
            return customerDAL.UpdateCustomerPassword(item);
        }

        public List<Customer> GetList()
        {
            return customerDAL.GetList();
        }

        public bool SaveCustomer(Customer newItem)
        {

            return customerDAL.Save(newItem);
        }
        public bool SaveImageDriverDetails(DriverImageRegister driverImageRegister)
        {

            return customerDAL.SaveImageDriverDetails(driverImageRegister);
        }

        public bool DeleteCustomer(Customer item)
        {
            return customerDAL.Delete(item);
        }

        public Customer GetCustomer(Customer item)
        {
            return (Customer)customerDAL.GetItem<Customer>(item);
        }

        public bool UpdateCustomerDevice(string mobileNo, string deviceID)
        {
            return customerDAL.UpdateCustomerDevice(mobileNo, deviceID);
        }
        public IEnumerable<CustomerBillDetails> GetCustomerPaymentDetails(string bookingNo)
        {
            return customerDAL.GetCustomerPaymentDetails(bookingNo);
        }

        public TripInvoice GetTripInvoiceList(TripInvoice tripInvoice)
        {
            return (TripInvoice)customerDAL.GetTripInvoice<TripInvoice>(tripInvoice);
        }

        public bool SaveCustomer(ContactUs contactUs)
        {

            return customerDAL.SaveContactUs(contactUs);
        }
    }
}
