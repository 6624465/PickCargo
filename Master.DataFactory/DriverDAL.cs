using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Master.Contract;
using Master.DataFactory;

namespace Master.DataFactory
{
    public class DriverDAL
    {
        private Database db;
        private DbTransaction currentTransaction = null;
        private DbConnection connection = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public DriverDAL()
        {

            db = DatabaseFactory.CreateDatabase("PickC");

        }

        #region IDataFactory Members

        public List<Driver> GetList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.LISTDRIVER, MapBuilder<Driver>.BuildAllProperties()).ToList();
        }

        public bool Save<T>(T item, DbTransaction parentTransaction) where T : IContract
        {
            currentTransaction = parentTransaction;
            return Save(item);

        }

        public bool Save<T>(T item) where T : IContract
        {
            var result = 0;
            var driver = (Driver)(object)item;

            if (currentTransaction == null)
            {
                connection = db.CreateConnection();
                connection.Open();
            }

            var transaction = (currentTransaction == null ? connection.BeginTransaction() : currentTransaction);

            try
            {

                var savecommand = db.GetStoredProcCommand(DBRoutine.SAVEDRIVER);
                db.AddInParameter(savecommand, "DriverID", System.Data.DbType.String, driver.DriverID);
                db.AddInParameter(savecommand, "DriverName", System.Data.DbType.String, driver.DriverName);
                db.AddInParameter(savecommand, "Password", System.Data.DbType.String, driver.Password ?? "pickcdriver");
                db.AddInParameter(savecommand, "VehicleNo", System.Data.DbType.String, driver.VehicleNo);
                db.AddInParameter(savecommand, "FatherName", System.Data.DbType.String, driver.FatherName);
                db.AddInParameter(savecommand, "DateOfBirth", System.Data.DbType.DateTime, driver.DateOfBirth);
                db.AddInParameter(savecommand, "PlaceOfBirth", System.Data.DbType.String, driver.PlaceOfBirth);
                db.AddInParameter(savecommand, "Gender", System.Data.DbType.Int16, driver.Gender);
                db.AddInParameter(savecommand, "MaritialStatus", System.Data.DbType.Int16, driver.MaritialStatus);
                db.AddInParameter(savecommand, "MobileNo", System.Data.DbType.String, driver.MobileNo);
                db.AddInParameter(savecommand, "PhoneNo", System.Data.DbType.String, driver.PhoneNo);
                db.AddInParameter(savecommand, "PANNo", System.Data.DbType.String, driver.PANNo);
                db.AddInParameter(savecommand, "AadharCardNo", System.Data.DbType.String, driver.AadharCardNo);
                db.AddInParameter(savecommand, "LicenseNo", System.Data.DbType.String, driver.LicenseNo);
                //db.AddInParameter(savecommand, "Status", System.Data.DbType.Boolean, driver.Status);
                db.AddInParameter(savecommand, "CreatedBy", System.Data.DbType.String, driver.CreatedBy);
                db.AddInParameter(savecommand, "ModifiedBy", System.Data.DbType.String, driver.ModifiedBy);
                //db.AddInParameter(savecommand, "DeviceID", System.Data.DbType.String, driver.DeviceID);
                db.AddInParameter(savecommand, "NewDocumentNo", System.Data.DbType.String, 50);


                result = db.ExecuteNonQuery(savecommand, transaction);

                if (result > 0)
                {
                    var newDocumentNo = savecommand.Parameters["@NewDocumentNo"].Value.ToString();

                    foreach (var addressItem in driver.AddressList)
                    {
                        addressItem.AddressLinkID = newDocumentNo;
                    }


                    driver.AddressList.ForEach(x =>
                    {
                        result = new AddressDAL().Save(x, transaction) == true ? 1 : 0;
                    });

                    if (currentTransaction == null)
                        transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                if (currentTransaction == null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                transaction.Dispose();
                connection.Close();

            }

            return (result > 0 ? true : false);

        }

        public bool Delete<T>(T item) where T : IContract
        {
            var result = false;
            var driver = (Driver)(object)item;

            var connnection = db.CreateConnection();
            connnection.Open();

            var transaction = connnection.BeginTransaction();

            try
            {
                var deleteCommand = db.GetStoredProcCommand(DBRoutine.DELETEDRIVER);
                db.AddInParameter(deleteCommand, "DriverID", System.Data.DbType.String, driver.DriverID);


                result = Convert.ToBoolean(db.ExecuteNonQuery(deleteCommand, transaction));

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
                connnection.Close();

            }

            return result;
        }

        public IContract GetItem<T>(IContract lookupItem) where T : IContract
        {
            var item = ((Driver)lookupItem);

            var driverItem = db.ExecuteSprocAccessor(DBRoutine.SELECTDRIVER,
                                                    MapBuilder<Driver>.BuildAllProperties(),
                                                    item.DriverID).FirstOrDefault();

            if (driverItem == null) return null;


            driverItem.AddressList = new AddressDAL().GetList(driverItem.DriverID);

            return driverItem;
        }


        #endregion
        public List<Driver> GetDriverByName<T>(IContract lookupItem) where T : IContract
        {
            var item = ((Driver)lookupItem);

            List<Driver> list = db.ExecuteSprocAccessor(DBRoutine.GETDRIVERBYNAME,
                                                       MapBuilder<Driver>.BuildAllProperties(), item.DriverName).ToList();
            return list;
        }

        public bool UpdateDriverDevice(string driverID, string deviceID)
        {
            var result = false;

            var connnection = db.CreateConnection();
            connnection.Open();

            var transaction = connnection.BeginTransaction();

            try
            {
                var deleteCommand = db.GetStoredProcCommand(DBRoutine.DRIVERUPDATEDEVICEID);
                db.AddInParameter(deleteCommand, "DriverID", System.Data.DbType.String, driverID);
                db.AddInParameter(deleteCommand, "DeviceID", System.Data.DbType.String, deviceID);



                result = Convert.ToBoolean(db.ExecuteNonQuery(deleteCommand, transaction));

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
                connnection.Close();

            }
            return result;

        }




    }
}
