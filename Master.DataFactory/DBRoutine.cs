using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.DataFactory
{
    public static class DBRoutine
    {


        /// <summary>
        /// [Master].[Customer]
        /// </summary>

        public const string SELECTCUSTOMER = "[Master].[usp_CustomerSelect]";
        public const string LISTCUSTOMER = "[Master].[usp_CustomerList]";
        public const string SAVECUSTOMER = "[Master].[usp_CustomerSave]";
        public const string DELETECUSTOMER = "[Master].[usp_CustomerDelete]";
        public const string CUSTOMERUPDATEPASSWORD = "[Master].[usp_CustomerUpdatePassword]";
        public const string CUSTOMERUPDATEDEVICEID = "[Master].[usp_UpdateCustomerDeviceID]";
        public const string CUSTOMERBILLDETAILS = "[Operation].[usp_CustomerBillDetails]";
        /// <summary>
        /// [Master].[VehicleConfig]
        /// </summary>

        public const string SELECTVEHICLECONFIG = "[Master].[usp_VehicleConfigSelect]";
        public const string LISTVEHICLECONFIG = "[Master].[usp_VehicleConfigList]";
        public const string SAVEVEHICLECONFIG = "[Master].[usp_VehicleConfigSave]";
        public const string DELETEVEHICLECONFIG = "[Master].[usp_VehicleConfigDelete]";




        /// <summary>
        /// [Config].[LookUp]
        /// </summary>

        public const string SELECTLOOKUP = "[Config].[usp_LookUpSelect]";
        public const string VEHICLEGROUPLIST = "[Master].[usp_VehicleGroupList]";
        public const string CARGOTYPELIST = "[Master].[usp_CargoTypeList]";
        public const string LISTLOOKUP = "[Config].[usp_LookUpList]";
        public const string SAVELOOKUP = "[Config].[usp_LookUpSave]";
        public const string DELETELOOKUP = "[Config].[usp_LookUpDelete]";

        /// <summary>
        /// [Master].[RateCard]
        /// </summary>

        public const string SELECTRATECARD = "[Master].[usp_RateCardSelect]";
        public const string LISTRATECARD = "[Master].[usp_RateCardList]";
        public const string SAVERATECARD = "[Master].[usp_RateCardSave]";
        public const string DELETERATECARD = "[Master].[usp_RateCardDelete]";

        public const string CUSTOMERLOGIN = "[Master].[usp_CustomerLogIn]";
        public const string VEHICLETYPELIST = "[Master].[usp_VehicleTypeList]";
        public const string LOADINGUNLOADINGLIST = "[Master].[usp_LoadingUnLoadingList]";

        /// <summary>
        /// [Master].[Address]
        /// </summary>

        public const string SELECTADDRESS = "[Master].[usp_AddressSelect]";
        public const string LISTADDRESS = "[Master].[usp_AddressList]";
        public const string SAVEADDRESS = "[Master].[usp_AddressSave]";
        public const string DELETEADDRESS = "[Master].[usp_AddressDelete]";

        /// <summary>
        /// [Master].[Driver]
        /// </summary>

        public const string SELECTDRIVER = "[Master].[usp_DriverSelect]";
        public const string LISTDRIVER = "[Master].[usp_DriverList]";
        public const string SAVEDRIVER = "[Master].[usp_DriverSave]";
        public const string DELETEDRIVER = "[Master].[usp_DriverDelete]";
        public const string DRIVERUPDATEDEVICEID = "[Master].[usp_UpdateDriverDeviceID]";
        public const string GETDRIVERBYSTATUS = "[Master].[usp_GetDriverByStatus]";
        public const string SAVEATTACHMENTS = "[Master].[usp_AttachmentsSave]";
        public const string SAVEMANUFACTURER = "[Master].[usp_SaveVehicleManufacturer]";
        public const string DRIVERUPDATEPASSWORD = "[Master].[usp_DriverUpdatePassword]";
        public const string LISTDRIVEROPERATORWISE = "[Master].[usp_DriverListOperatorWise]";
        public const string LISTBANKDETAILSOPERATORWISE = "[Master].[usp_BankListOperatorWise]";
        public const string DRIVERTodayListOfTrips = "[Operation].[usp_DriverWiseTripList]";
        public const string GETDRIVERTRIPAMOUNTBYPAYMENTTYPE = "[Operation].[usp_SumDriverWiseDailyAmountPaymentType]";
        /// <summary>
        /// [Master].[Operator]
        /// </summary>

        public const string SELECTOPERATOR = "[Master].[usp_OperatorSelect]";
        public const string SELECTOPERATORBYOPERATORID = "[Master].[usp_OperatorSelectByOperatorID]";
        public const string LISTOPERATOR = "[Master].[usp_OperatorList]";
        public const string SAVEOPERATOR = "[Master].[usp_OperatorSave]";
        public const string DELETEPERATOR = "[Master].[usp_OperatorDelete]";    
        public const string SAVEOPERATORATTACHMENTS = "[Master].[usp_OperatorAttachmentsSave]";
        public const string OPERATORUPDATEPASSWORD = "[Master].[usp_OperatorUpdatePassword]";
        public const string OPERATORVALIDCHECK = "[Master].[usp_OperatorValidCheck]";

        /// <summary>
        /// [Master].[OperatorDriver]
        /// </summary>

        public const string SELECTDRIVERDETAILS = "[Master].[usp_DriverListDetails]";
        public const string SELECTVEHICLENODETAILS = "[Master].[usp_OperatorVehicleNoList]";
        public const string SAVEOPERATORDRIVERLIST = "[Master].[usp_OperatorDriverSave]";
        public const string SELECTOPERATORDRIVERTOTALLIST = "[Master].[usp_OperatorDriverSelect]";
        public const string SELECTOPERATORDRIVERBYID = "[Master].[usp_OperatorDriverSelectByOperatorDriverId]";
        public const string UPDATEOPERATORDRIVERVEHICLEATTACHMENTLIST = "[Master].[usp_OperatorDriverVehicleAttachment]";

        /// <summary>
        /// [Master].[TruckList]
        /// </summary>
        /// 
        public const string LISTTRUCK = "[Master].[usp_GetTruckList]";
        public const string SELECTTRUCK = "[Master].[usp_SelectTruckListbyType]";
        /// <summary>
        /// [Master].[TripCount]
        /// </summary>
        /// 
        public const String OPERATORTRIPCOUNT = "[Operation].[usp_OperatorWiseTripCount]";
        public const string OPERATORTRIPAMOUNT = "[Operation].[usp_SumOperatorWiseDailyAmount]";
        public const string OPERATORTRIPCOUNTAMOUNTBYDATES = "[Operation].[usp_SumOperatorWiseSearchDatesCountAmount]";
        public const string OPERATORTRIPCOUNTAMOUNTLISTBYDATES = "[Operation].[usp_OperatorWiseListCountAmount]";
        public const string DRIVERTRIPCOUNTBYDRIVERID = "[Operation].[usp_DriverWiseTripCount]";
        public const string DRIVERTRIPAMOUNTDAILYWISE = "[Operation].[usp_SumDriverWiseDailyAmount]";
        public const string OPERATORTRIPEARNINGLISTDAILY = "[Operation].[usp_OperatorWiseDailyAmountList]";
        public const string OPERATORTRIPCOUNTLISTDAILY = "[Operation].[usp_OperatorWiseDailyCountList]";


        /// <summary>
        /// [Master].[DriverRating]
        public const string SELECTDRIVERRATING = "[Master].[usp_DriverRatingSelect]";
        public const string LISTDRIVERRATING = "[Master].[usp_DriverRatingList]";
        public const string SAVEDRIVERRATING = "[Master].[usp_DriverRatingSave]";
        public const string DELETEDRIVERRATING = "[Master].[usp_DriverRatingDelete]";
        public const string SELECTDRIVERAVERAGERATING = "[Master].[usp_DriverRatingSelectByDriverID]";
        /// </summary>

        /// <summary>
        /// [Master].[BankDetails]
        /// </summary>

        public const string SELECTBANKDETAILS ="[Master].[usp_BankDetailsSelect]";
        public const string LISTBANKDETAILS = "[Master].[usp_BankDetailsList]";
        public const string SAVEBANKDETAILS = "[Master].[usp_BankDetailsSave]";
        public const string DELETEBANKDETAILS = "[Master].[usp_BankDetailsDelete]";

        /// <summary>
        /// [Master].[ReferralDriver]
        /// </summary>

        public const string SELECTREFERRALDRIVER = "[Master].[usp_DriverReferralSelect]";
        public const string LISTREFERRALDRIVER = "[Master].[usp_DriverReferralList]";
        public const string SAVEREFERRALDRIVER = "[Master].[usp_DriverReferralSave]";
        public const string DELETEREFERRALDRIVER = "[Master].[usp_DriverReferralDelete]";

        /// <summary>
        /// [Master].[OperatorNotifications]
        /// </summary>

        public const string SELECTOPERATORNOTIFICATIONS = "[Master].[usp_OperatorNotificationsSelect]";
        public const string LISTOPERATORNOTIFICATIONS = "[Master].[usp_OperatorNotificationsList]";
        public const string SAVEOPERATORNOTIFICATIONS = "[Master].[usp_OperatorNotificationsSave]";
        public const string DELETEOPERATORNOTIFICATIONS = "[Master].[usp_OperatorNotificationsDelete]";

        public const string TRIPINVOICELIST = "[Operation].[usp_CustomerInvoiceReport]";


        ///// <summary>
        ///// [Master].[DriverVehicle]
        ///// </summary>

        //public const string SELECTDRIVERVEHICLE = "[Master].[usp_DriverVehicleSelect]";
        //public const string LISTDRIVERVEHICLE = "[Master].[usp_DriverVehicleList]";
        //public const string SAVEDRIVERVEHICLE = "[Master].[usp_DriverVehicleSave]";
        //public const string DELETEDRIVERVEHICLE = "[Master].[usp_DriverVehicleDelete]";

        /// <summary>
        /// [Master].[CustomerContactUs]
        /// Added By Meena Konakondla
        /// </summary>
        /// 

        public const string SAVECUSTOMERCONTACTUS = "[Master].[usp_CustomerContactUsSave]";


    }
}
