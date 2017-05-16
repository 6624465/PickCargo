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
using PickC.Services.DTO;
using Operation.DataFactory;

namespace Master.DataFactory
{
  public  class OperatorDAL
    {
        private Database db;
        private DbTransaction currentTransaction = null;
        private DbConnection connection = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public OperatorDAL()
        {

            db = DatabaseFactory.CreateDatabase("PickC");

        }
        public List<Operator> GetList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.LISTOPERATOR, MapBuilder<Operator>.BuildAllProperties()).ToList();
        }
        public bool Save<T>(T item, DbTransaction parentTransaction) where T : IContract
        {
            currentTransaction = parentTransaction;
            return Save(item);

        }

        public bool Save<T>(T item) where T : IContract
        {
            var result = 0;
            var OPerator = (Operator)(object)item;

            if (currentTransaction == null)
            {
                connection = db.CreateConnection();
                connection.Open();
            }

            var transaction = (currentTransaction == null ? connection.BeginTransaction() : currentTransaction);

            try
            {
                var savecommand = db.GetStoredProcCommand(DBRoutine.SAVEOPERATOR);
                db.AddInParameter(savecommand, "OperatorID", System.Data.DbType.String,OPerator.OperatorID ?? "");
                db.AddInParameter(savecommand, "OperatorName", System.Data.DbType.String, OPerator.OperatorName);
                db.AddInParameter(savecommand, "Password", System.Data.DbType.String, OPerator.Password ?? "pickcoperator");
                db.AddInParameter(savecommand, "FatherName", System.Data.DbType.String, OPerator.FatherName);
                db.AddInParameter(savecommand, "DateOfBirth", System.Data.DbType.DateTime, OPerator.DateOfBirth);
                db.AddInParameter(savecommand, "PlaceOfBirth", System.Data.DbType.String, OPerator.PlaceOfBirth);
                db.AddInParameter(savecommand, "Gender", System.Data.DbType.Int16, OPerator.Gender);
                db.AddInParameter(savecommand, "MaritialStatus", System.Data.DbType.Int16, OPerator.MaritialStatus);
                db.AddInParameter(savecommand, "MobileNo", System.Data.DbType.String, OPerator.MobileNo);
                db.AddInParameter(savecommand, "PhoneNo", System.Data.DbType.String, OPerator.PhoneNo);
                db.AddInParameter(savecommand, "PANNo", System.Data.DbType.String, OPerator.PANNo);
                db.AddInParameter(savecommand, "AadharCardNo", System.Data.DbType.String, OPerator.AadharCardNo);
                db.AddInParameter(savecommand, "CreatedBy", System.Data.DbType.String, OPerator.CreatedBy);
                db.AddInParameter(savecommand, "ModifiedBy", System.Data.DbType.String, OPerator.ModifiedBy);
                db.AddInParameter(savecommand, "Nationality", System.Data.DbType.String, OPerator.Nationality?? "Indian");
                db.AddOutParameter(savecommand, "NewDocumentNo", System.Data.DbType.String,50);
                       result = db.ExecuteNonQuery(savecommand, transaction);
                if (result > 0)
                {
                    OPerator.OperatorID = savecommand.Parameters["@NewDocumentNo"].Value.ToString();
                    if(OPerator.OperatorDriverList !=null && OPerator.OperatorDriverList.Count > 0)
                    {
                        foreach(var operatorDriverList in OPerator.OperatorDriverList)
                        {
                            operatorDriverList.OperatorDriverId = OPerator.OperatorID;
                        }
                        OPerator.OperatorDriverList.ForEach(x =>
                        {
                            result = new OperatorDriverDAL().Save(x, transaction) == true ? 1 : 0;
                        });
                    }
                    if (OPerator.OperatorVehicle != null && OPerator.OperatorVehicle.Count > 0)
                    {
                        foreach (var operatorVehicle in OPerator.OperatorVehicle)
                        {
                            operatorVehicle.OperatorVehicleID = OPerator.OperatorID;
                        }
                        OPerator.OperatorVehicle.ForEach(x =>
                        {
                            result = new OperatorVehicleDAL().Save(x, transaction) == true ? 1 : 0;
                        });
                    }
                    if (OPerator.AddressList != null && OPerator.AddressList.Count > 0)
                    {
                        foreach (var addressItem in OPerator.AddressList)
                        {
                            addressItem.AddressLinkID = OPerator.OperatorID;
                        }
                        OPerator.AddressList.ForEach(x =>
                        {
                            result = new AddressDAL().Save(x, transaction) == true ? 1 : 0;
                        });
                    }
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
        public IContract GetItem<T>(IContract lookupItem) where T : IContract
        {
            var item = ((Operator)lookupItem);

            var operatorItem = db.ExecuteSprocAccessor(DBRoutine.SELECTOPERATOR,
                                                    MapBuilder<Operator>
                                                    .MapAllProperties()
                                                    .DoNotMap(x => x.Nationality).Build(),
                                                    item.OperatorID).FirstOrDefault();

            if (operatorItem == null) return null;


            operatorItem.AddressList = new AddressDAL().GetList(operatorItem.OperatorID);

            return operatorItem;
        }
        public bool Delete<T>(T item) where T : IContract
        {
            var result = false;
            var OPerator = (Operator)(object)item;

            var connnection = db.CreateConnection();
            connnection.Open();

            var transaction = connnection.BeginTransaction();

            try
            {
                var deleteCommand = db.GetStoredProcCommand(DBRoutine.DELETEPERATOR);
                db.AddInParameter(deleteCommand, "OperatorID", System.Data.DbType.String, OPerator.OperatorID);

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
        public bool SaveAttachment(OperatorAttachmentDTO attachment)
        {
            var result = false;
            var connection = db.CreateConnection();
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var saveCommand = db.GetStoredProcCommand(DBRoutine.SAVEOPERATORATTACHMENTS);
                db.AddInParameter(saveCommand, "AttachmentId", System.Data.DbType.String, attachment.attachmentId);
                db.AddInParameter(saveCommand, "OperatorID", System.Data.DbType.String, attachment.operatorId);
                db.AddInParameter(saveCommand, "LookupCode", System.Data.DbType.String, attachment.lookupCode);
                db.AddInParameter(saveCommand, "ImagePath", System.Data.DbType.String, attachment.imagePath);

                result = Convert.ToBoolean(db.ExecuteNonQuery(saveCommand, transaction));

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            return result;
        }
        #region IDataFactory Members
    }
    #endregion
}
