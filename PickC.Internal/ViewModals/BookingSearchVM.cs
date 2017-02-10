using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Operation.Contract;

namespace PickC.Internal.ViewModals
{
    public class BookingSearchVM
    {
        public List<Booking> booking { get; set; }
        public SearchDates dates { get; set; }

    }
    public class SearchDates {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}