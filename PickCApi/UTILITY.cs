﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickCApi
{
    public static class UTILITY
    {
        public static string SUCCESSMESSAGE = "Success"; //krishna & Srinath
        public static string FAILEDMESSAGE = "Failed"; //krishna & Srinath
        public static string SUCCESSMSG = "SAVED SUCSSFULLY";
        public static string DELETEMSG = "DELETED SUCSSFULLY";
        public static string FAILEDAUTH = "MOBILENO OR AUTH TOKEN IS MISSING";
        public static string INVALID = "INVALID MOBILENO OR AUTH TOKEN";
        public static string LOGOUT = "USER LOGGEDOUT SUCCESSFULLY";
        public static string DEFAULTUSER = "ADMIN";
        public static string FAILEDMSG = "Operation failed";

        public static string NotifyCustomer = "Booking Cancelled by System";
        public static string NotifyCustomerFail = "Booking Cancelled by System is Failed";
        public static string NotifySuccess = "Booking Confirmed";//done
        public static string NotifyFailed = "Booking Failed";
        public static string NotifyCancelledByDriver = "Booking Cancelled by driver";//done
        public static string NotifyDriverpaymentReceived = "DriverpaymentReceived";
        public static string NotifyTripStart = "Trip Started";//pending
        public static string NotifyTripEnd = "Trip End";//pending
        public static string NotifyInvoiceGenerated = "Invoice Generated";//pending
        public static string NotifyNewBooking = "New Booking Available";
        public static string NotifyBookingCancelledByUser = "Booking Cancelled by user";//done
        public static string NotifyPaymentDriver = "Customer Payment Received";//done
        public static string NotifyBookingAcceptedByOtherDriver = "Booking Accepted by other driver";
        public static string NotifyPickUpReachDateTime = "Driver reached pickup location";
        public static string NotifyDestinationReachDateTime = "Driver reached destination location";

        public static short radius = 4;//2
        public static string SmsOTP = "OTP for PICKC: {0}";
        public static string SmsConfirmTrip = "Your booking has been confirmed. Your trip will be started soon...PICKC";
        public static string SmsConfirmBooking = "Your booking has been confirmed. Your booking no. is {0}...PICKC";

        public enum HEADERKEYS
        {
            AUTH_TOKEN,
            DRIVERID,
            LATITUDE,
            LONGITUDE,
            MOBILENO,
            TYPE
        }
    }

    
}