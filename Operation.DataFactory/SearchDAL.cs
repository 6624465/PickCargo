using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Operation.Contract;
using Operation.DataFactory;
namespace Operation.DataFactory
{
   public class SearchDAL
    {
        private Database db;
        private DbTransaction currentTransaction = null;
        private DbConnection connection = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public SearchDAL()
        {

            db = DatabaseFactory.CreateDatabase("PickC");

        }

        public List<Booking> SearchBookings(string bookingNo, DateTime? bookingDate, int vehicleGroup, int vehicleType,string customerName,string vehicleNumber)
        {


            return db.ExecuteSprocAccessor(DBRoutine.BOOKINGSEARCH,
                                            MapBuilder<Booking>
                                            .BuildAllProperties(),
                                            bookingNo, bookingDate, vehicleGroup, vehicleType, customerName, vehicleNumber).ToList();
        }



    }
}
