using Operation.Contract;
using Operation.DataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.BusinessFactory
{
    public class SearchBO
    {

        private SearchDAL searchDAL;
        public SearchBO()
        {
            searchDAL = new SearchDAL();
        }

        public List<Booking> SearchBookings(string bookingNo, DateTime? bookingDate,
            int vehicleGroup, int vehicleType,
            string customerName, string vehicleNumber)
        {
            return searchDAL.SearchBookings(
                bookingNo, bookingDate,
                vehicleGroup, vehicleType,
                customerName, vehicleNumber
                );
        }

        public List<Booking> BookingByDate(DateTime fromdate , DateTime todate) {
            return searchDAL.BookingsByDate(fromdate,todate);
        }
    }
}
