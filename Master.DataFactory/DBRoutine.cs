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

    }
}
