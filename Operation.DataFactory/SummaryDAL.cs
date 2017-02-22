using Microsoft.Practices.EnterpriseLibrary.Data;
using Operation.Contract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.DataFactory
{
    public class SummaryDAL
    {
        private Database db;
        private DbTransaction currentTransaction = null;
        private DbConnection connection = null;

        public SummaryDAL()
        {
            db = DatabaseFactory.CreateDatabase("PickC");
        }

        public IContract GetSummary<T>(string DriverID) where T:Summary
        {
            return db.ExecuteSprocAccessor(DBRoutine.DRIVERSUMMARY,MapBuilder<Summary>.BuildAllProperties(), DriverID).FirstOrDefault();
        }

        public List<DriverPayments> GetPayments(string DriverID)
        {
            return db.ExecuteSprocAccessor(DBRoutine.DRIVERPAYMENTS,MapBuilder<DriverPayments>.BuildAllProperties(), DriverID).ToList();
        }
    }
}
