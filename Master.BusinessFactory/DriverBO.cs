using System;
using System.Collections.Generic;
using Master.Contract;
using Master.DataFactory;
using PickC.Services.DTO;

namespace Master.BusinessFactory
{
    public class DriverBO
    {
        private DriverDAL driverDAL;
        public DriverBO()
        {
            driverDAL = new DriverDAL();
        }
        public List<Driver> GetList()
        {
            return driverDAL.GetList();
        }
        public List<DriverDetails> GetDriversDetailList()
        {
            return driverDAL.GetDriversDetailList();
        }
        public int GetTripCount(string MobileNo)
        {
            return driverDAL.GetTripCount(MobileNo);
        }
        public int GetTripCountbyDriverID(string DriverID)
        {
            return driverDAL.GetTripCountbyDriverID(DriverID);
        }
        public decimal GetTripAmount(string MobileNo)
        {
            return driverDAL.GetTripAmount(MobileNo);
        }
        public decimal GetTripAmountbyDriverID(string DriverID)
        {
            return driverDAL.GetTripAmountbyDriverID(DriverID);
        }
        public bool SaveDriver(Driver newItem)
        {

            return driverDAL.Save(newItem);
        }
        public bool SaveDriverReferral(DriverReferral newItem)
        {

            return driverDAL.SaveDriverReferral(newItem);
        }

        public bool DeleteDriver(Driver item)
        {
            return driverDAL.Delete(item);
        }
        public List<TripCE> GetTripCountEarnings(string MobileNo,DateTime fromdate, DateTime todate)
        {
            return driverDAL.GetTripCountandEarnings(MobileNo,fromdate,todate);
        }
        public List<DriverTodayTripList> GetTodayListOfTrips(string DriverID)
        {
            return driverDAL.GetTodayListOfTrips(DriverID);
        }
        public List<TripCElist> GetTripCountEarningsList(string MobileNo, DateTime fromdate, DateTime todate)
        {
            return driverDAL.GetTripCountandEarningsList(MobileNo, fromdate, todate);
        }
        public List<TripCElist> GetTripEarningsList(string MobileNo)
        {
            return driverDAL.GetDailyTripEarningsList(MobileNo);
        }
        public List<TripCountList> GetTripCountsList(string MobileNo)
        {
            return driverDAL.GetDailyTripCountList(MobileNo);
        }
        public Driver GetDriver(Driver item)
        {
            return (Driver)driverDAL.GetItem<Driver>(item);
        }
        public List<DriverEarningPaymentType> GetDriverTripAmountbyPaymentType(string DriverID)
        {
            return driverDAL.GetDriverTripAmountbyPaymentType(DriverID);
        }
        public DriverRating GetDriverRating(DriverRating item)
        {
            return (DriverRating)driverDAL.GetDriverRating<DriverRating>(item);
        }


        public bool UpdateDriverDevice(string driverID, string deviceID)
        {
            return driverDAL.UpdateDriverDevice(driverID, deviceID);
        }

        public List<Driver> GetDriverBySearch(bool? status)
        {
            return (List<Driver>)driverDAL.GetDriverBySearch(status);
        }

        public bool SaveAttachment(DriverAttachmentsDTO attachment)
        {
            return driverDAL.SaveAttachment(attachment);
        }
        public bool UpdateDriverPassword(DriverPassword item)
        {
            return driverDAL.UpdateDriverPassword(item);
        }
        public List<Driver> GetOperatorWiseDriverList(string MobileNo)
        {
            return driverDAL.GetOperatorWiseDriverList(MobileNo);
        }
        public bool SaveDriverRating(DriverRating driverRating)
        {
            return driverDAL.SaveDriverRating(driverRating);
        }
        public DriverTripInvoice GetDriverTripInvoice(DriverTripInvoice driverTripInvoice)
        {
            return (DriverTripInvoice)driverDAL.GetDriverTripInvoice<DriverTripInvoice>(driverTripInvoice);
        }
    }
}
