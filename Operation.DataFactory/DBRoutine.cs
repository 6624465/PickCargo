using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.DataFactory
{
    public static class DBRoutine
    {


        /// <summary>
        /// [Operation].[Trip]
        /// </summary>

        public const string SELECTTRIP = "[Operation].[usp_TripSelect]";
        public const string LISTTRIP = "[Operation].[usp_TripList]";
        public const string SAVETRIP = "[Operation].[usp_TripSave]";
        public const string DELETETRIP = "[Operation].[usp_TripDelete]";
        public const string TRIPEND = "[Operation].[usp_TripEnd]";
        public const string CUSTOMERCURRENTTRIP = "[Operation].[usp_CustomerCurrentTrip]";
        public const string DRIVERCURRENTTRIP = "[Operation].[usp_DriverCurrentTrip]";
        public const string TRIPUPDATETRAVELLEDDISTANCE = "[Operation].[usp_UpdateTripTravelledDistance]";


        /// <summary>
        /// [Operation].[Invoice]
        /// </summary>

        public const string SELECTINVOICE = "[Operation].[usp_InvoiceSelect]";
        public const string LISTINVOICE = "[Operation].[usp_InvoiceList]";
        public const string SAVEINVOICE = "[Operation].[usp_InvoiceSave]";
        public const string DELETEINVOICE = "[Operation].[usp_InvoiceDelete]";
        public const string SELECTINVOICEBYBOOKINGNO = "[Operation].[usp_InvoiceSelectByBookingNo]";




        /// <summary>
        /// [Operation].[Booking]
        /// </summary>

        public const string SELECTBOOKING = "[Operation].[usp_BookingSelect]";
        public const string LISTBOOKING = "[Operation].[usp_BookingList]";
        public const string SAVEBOOKING = "[Operation].[usp_BookingSave]";
        public const string DELETEBOOKING = "[Operation].[usp_BookingDelete]";
        public const string LISTOFBOOKINGBYMOBILENO = "[Operation].[usp_BookingListByMobileNo]";
        public const string LISTNEARBOOKINGSFORDRIVER = "[Operation].[usp_NearBookingsForDriver]";

        public const string SAVEPICKUPREACHDATETIME = "[Operation].[usp_SavePickupReachDateTime]";
        public const string SAVEDESTINATIONREACHDATETIME = "[Operation].[usp_SaveDestinationReachDateTime]";


        /// <summary>
        /// [Operation].[CustomerLogin]
        /// </summary>

        public const string SELECTCUSTOMERLOGIN = "[Operation].[usp_CustomerLoginSelect]";
        public const string LISTCUSTOMERLOGIN = "[Operation].[usp_CustomerLoginList]";
        public const string SAVECUSTOMERLOGIN = "[Operation].[usp_CustomerLoginSave]";
        public const string DELETECUSTOMERLOGIN = "[Operation].[usp_CustomerLoginDelete]";
        public const string AUTHENTICATEUSER = "[Operation].[usp_AUTHENTICATE_USER]";
        public const string CUSTOMERLOGIN = "[Operation].[usp_DoCustomerLogIn]";



        /// <summary>
        /// [Operation].[TripMonitor]
        /// </summary>

        public const string DELETETRIPMONITOR = "[Operation].[usp_TripMonitorDelete]";
        public const string SELECTTRIPMONITOR = "[Operation].[usp_TripMonitorSelect]";
        public const string LISTTRIPMONITOR = "[Operation].[usp_TripMonitorList]";
        public const string LISTTRIPMONITOR2 = "[Operation].[usp_TripMonitorList2]";
        public const string SAVETRIPMONITOR = "[Operation].[usp_TripMonitorSave]";


        public const string SELECTDRIVERACTIVITY = "[Operation].[usp_DriverActivitySelect]";
        public const string LISTDRIVERACTIVITY = "[Operation].[usp_DriverActivityList]";
        public const string SAVEDRIVERACTIVITY = "[Operation].[usp_DriverActivitySave]";
        public const string DELETEDRIVERACTIVITY = "[Operation].[usp_DriverActivityDelete]";
        public const string DRIVERLOGIN = "[Operation].[usp_DoDriverLogIn]";
        public const string UPDATEDRIVERDUTYSTATUS = "[Operation].[usp_UpdateDriverDutyStatus]";
        public const string AUTHENTICATEDRIVER = "[Operation].[usp_AUTHENTICATE_DRIVER]";
        public const string SELECTDRIVERACTIVITYBYDRIVERID = "[Operation].[usp_DriverActivitySelectByDriverID]";


        public const string LISTNEARTRUCKSINRANGE = "[Operation].[usp_NearTrucksInRange]";
        public const string BOOKINGCANCELLEDBYDRIVER = "[Operation].[usp_BookingCancelledByDriver]";



        public const string BOOKINGCONFIRMBYDRIVER = "[Operation].[usp_BookingConfirmByDriver]";
        public const string ISBOOKINGALREADYCONFIRMED = "[Operation].[usp_IsBookingAlreadyConfirmed]";
        public const string GETCUSTOMERDEVICEIDBYBOOKINGNO = "[Operation].[usp_GetCustomerDeviceIDByBookingNo]";
        public const string GETCUSTOMERDEVICEIDBYTRIPID = "[Operation].[usp_GetCustomerDeviceIDByTripID]";
        public const string GETDRIVERDEVICEIDBYBOOKINGNO = "[Operation].[usp_GetDriverDeviceIDByBookingNo]";
        public const string NEARTRUCKSDEVICELIST = "[Operation].[usp_NearTrucksDeviceList]";


        public const string BOOKINGSEARCH = "[Operation].[usp_GetCurrentBookings]";
        public const string BOOKINGBYDATES = "[Operation].[usp_BookingSearchByDate]";


        //Driver Summary

        public const string DRIVERSUMMARY = "[Operation].[usp_GetDriverSummary]";
        public const string DRIVERPAYMENTS="[Operation].[usp_GetDriverPayments]";

    }
}
