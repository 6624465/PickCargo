using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master.Contract;

namespace PickC.Services.DTO
{
  public class PendingAmountDTO
    {
        public List<PendingAmount> pendingAmount { get; set; }
        public SearchDates dates { get; set; }

        public class SearchDates
        {
            public DateTime DateFrom { get; set; }
            public DateTime DateTo { get; set; }
        }
    }
}
