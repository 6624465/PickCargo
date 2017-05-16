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

        public List<Booking> SearchBookings(string bookingNo,
            DateTime? bookingDate, int vehicleGroup, int vehicleType,string customerName,string vehicleNumber)
        {


            return db.ExecuteSprocAccessor(DBRoutine.BOOKINGSEARCH,
                                            MapBuilder<Booking>
                                            .BuildAllProperties(),
                                            bookingNo, bookingDate, vehicleGroup, vehicleType, customerName, vehicleNumber).ToList();
        }

        public List<Booking> BookingsByDate(DateTime fromdate,DateTime todate) {
            return db.ExecuteSprocAccessor(DBRoutine.BOOKINGBYDATES, MapBuilder<Booking>.BuildAllProperties(), fromdate, todate).ToList();
        }
        public List<Booking> CurrentBookingsByStatus(int? Status)
        {
            return db.ExecuteSprocAccessor(DBRoutine.LISTOFBOOKINGBYSTATUS, MapBuilder<Booking>.BuildAllProperties(),Status).ToList();
        }
        public List<Booking> GetList()
        {
            return db.ExecuteSprocAccessor(DBRoutine.LISTOFCURRENTBOOKING, MapBuilder<Booking>.BuildAllProperties()).ToList();
        }
        public List<BookingHistory> SearchBookingsHistory(string bookingNo, string CustomerMobileNo
          ,DateTime? bookingFrom, DateTime? bookingTo)
        {
            return db.ExecuteSprocAccessor(DBRoutine.BOOKINGHISTORYSEARCH,
                                             MapBuilder<BookingHistory>
                                             .BuildAllProperties(),
                                             bookingNo, CustomerMobileNo, bookingFrom, bookingTo).ToList();
        }
    }
}
