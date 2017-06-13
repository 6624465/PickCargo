using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
    public class TripInvoice : IContract
    {
        public string InvoiceNo { get; set; }
        public string BookingNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerMobileNo { get; set; }
        public string CustomerName { get; set; }
        public string TripID { get; set; }
        public decimal BaseKM { get; set; }
        public decimal BaseFare { get; set; }
        public decimal DistanceKM { get; set; }
        public decimal DistanceFare { get; set; }
        public Int16 TravelTime { get; set; }
        public decimal TravelTimeFare { get; set; }
        public decimal LoadingUnLoadingCharges { get; set; }
        public decimal WaitingCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal TotalDistanceKm { get; set; }
        public string DriverID { get; set; }
        public string DriverName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Tax1 { get; set; }
        public decimal Tax2 { get; set; }
        public string PaymentType { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal TotalFare { get; set; }
        public string VehicleType { get; set; }
        public string VehicleGroup { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleMaker { get; set; }

    }
}
