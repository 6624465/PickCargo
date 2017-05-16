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
public class OperatorDriverDAL
    {
        private Database db;
        private DbTransaction currentTransaction = null;
        private DbConnection connection = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public OperatorDriverDAL()
        {

            db = DatabaseFactory.CreateDatabase("PickC");

        }

        #region IDataFactory Members
        public List<OperatorDriver> GetList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.SELECTDRIVERDETAILS, MapBuilder<OperatorDriver>.BuildAllProperties()).ToList();

        }
        public List<OperatorVehuicleAttachedNo> GetVehicleNoList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.SELECTVEHICLENODETAILS, MapBuilder<OperatorVehuicleAttachedNo>.BuildAllProperties()).ToList();
        }
        public List<OperatorDriverList> GetOperatorDriverList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.SELECTOPERATORDRIVERTOTALLIST, MapBuilder<OperatorDriverList>.BuildAllProperties()).ToList();
        }
        public bool Save<T>(T item, DbTransaction parentTransaction) where T :IContract
        {
            currentTransaction = parentTransaction;
            return Save(item);

        }
        public bool Save<T>(T item) 
        {
            var result = 0;
            var operatorDriverList = (OperatorDriverList)(object)item;

            if (currentTransaction == null)
            {
                connection = db.CreateConnection();
                connection.Open();
            }

            var transaction = (currentTransaction == null ? connection.BeginTransaction() : currentTransaction);

            try
            {
                var savecommand = db.GetStoredProcCommand(DBRoutine.SAVEOPERATORDRIVERLIST);
                db.AddInParameter(savecommand, "OperatorDriverId", System.Data.DbType.String, operatorDriverList.OperatorDriverId);
                db.AddInParameter(savecommand, "DriverName", System.Data.DbType.String, operatorDriverList.DriverName);
                db.AddInParameter(savecommand, "DriverLicenseNo", System.Data.DbType.String,operatorDriverList.DriverLicenseNo);
                db.AddInParameter(savecommand, "DriverMobileNo", System.Data.DbType.String, operatorDriverList.DriverMobileNo);
                db.AddInParameter(savecommand, "VehicleattachedNo", System.Data.DbType.String, operatorDriverList.VehicleattachedNo);
                db.AddInParameter(savecommand, "CreatedBy", System.Data.DbType.String, operatorDriverList.CreatedBy ?? "");
                db.AddInParameter(savecommand, "ModifiedBy", System.Data.DbType.String, operatorDriverList.ModifiedBy ?? "");
                result = db.ExecuteNonQuery(savecommand, transaction);

                if (currentTransaction == null)
                    transaction.Commit();

            }
            catch (Exception ex)
            {
                if (currentTransaction == null)
                    transaction.Rollback();

                throw;
            }
            return (result > 0 ? true : false);

        }
    }
    #endregion
}
