using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Operation.Contract;
using Operation.BusinessFactory;

using Master.Contract;
using Master.BusinessFactory;

using PickCApi.Core;
using PickCApi.Areas.Operation.DTO;
using PickC.Services.DTO;

namespace PickCApi.Areas.Operation.Controllers
{
    [RoutePrefix("api/operation/booking")]
    [ApiAuthFilter]
    public class BookingController : ApiBase
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult BookingList()
        {
            try
            {
                var bookingList = new BookingBO().GetList();
                if (bookingList != null)
                    return Ok(bookingList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("list/{mobileNo}")]
        public IHttpActionResult BookingList(string mobileNo)
        {
            try
            {
                var bookingList = new BookingBO().GetListByMobileNo(mobileNo);
                if (bookingList != null)
                    return Ok(bookingList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveBooking(Booking booking)
        {
            try
            {
                var result = new BookingBO().SaveBooking(booking);
                if (result)
                {
                    var driverList = new BookingBO().GetNearTrucksDeviceID(booking.BookingNo, 
                        UTILITY.radius, 
                        booking.VehicleType, 
                        booking.VehicleGroup,
                        booking.Latitude,
                        booking.Longitude);//UTILITY.radius
                    if (driverList.Count > 0)
                    {
                        PushNotification(driverList.Select(x => x.DeviceID).ToList<string>(),
                            booking.BookingNo, UTILITY.NotifyNewBooking);
                    }
                    return Ok(new
                    {
                        bookingNo = booking.BookingNo,
                        message = UTILITY.SUCCESSMSG
                    });
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("isconfirm/{bookingNo}")]
        public IHttpActionResult IsConfirmBooking(string bookingNo)
        {
            try
            {
                var booking = new BookingBO().GetBooking(new Booking
                {
                    BookingNo = bookingNo
                });

                var driverInfo = new Driver();
                var driverActivity = new DriverActivity();                
                if (booking.IsConfirm)
                {
                    driverInfo = new DriverBO().GetDriver(new Driver { DriverID = booking.DriverID });
                    driverActivity = new DriverActivityBO().GetDriverActivityByDriverID(new DriverActivity { DriverID = booking.DriverID });
                }

                if (booking != null)
                    return Ok(new
                    {
                        isConfirm = booking.IsConfirm,
                        driverId = driverInfo.DriverID ?? "",
                        vehicleNo = driverInfo.VehicleNo ?? "",
                        driverName = driverInfo.DriverName ?? "",
                        driverImage = "",
                        MobileNo = driverInfo.MobileNo ?? "",
                        latitude = driverActivity.CurrentLat,
                        longitude = driverActivity.CurrentLong
                    });
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{bookingNo}")]
        public IHttpActionResult BookingByBookingNo(string bookingNo)
        {
            try
            {
                var booking = new BookingBO().GetBooking(new Booking {
                    BookingNo = bookingNo });

                if (booking != null)
                    return Ok(booking);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteByBookingNo(DeleteBookingDTO deleteBookingDTO)
        {
            try
            {
                var result = new BookingBO().DeleteBooking(new Booking { BookingNo = deleteBookingDTO.bookingNo });
                if (result)
                {
                    PushNotification(new BookingBO().GetDriverDeviceIDByBookingNo(deleteBookingDTO.bookingNo),
                        deleteBookingDTO.bookingNo, 
                        UTILITY.NotifyBookingCancelledByUser);

                    return Ok(UTILITY.DELETEMSG);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /* only for driver */
        [HttpGet]
        [Route("driver")]
        public IHttpActionResult GetNearBookingsForDriver()
        {            
            try
            {

                var bookingsList = new BookingBO().GetNearBookingsForDriver(
                    new Guid(HeaderValueByKey(UTILITY.HEADERKEYS.AUTH_TOKEN.ToString())),
                    HeaderValueByKey(UTILITY.HEADERKEYS.DRIVERID.ToString()),
                    Convert.ToDecimal(HeaderValueByKey(UTILITY.HEADERKEYS.LATITUDE.ToString())),
                    Convert.ToDecimal(HeaderValueByKey(UTILITY.HEADERKEYS.LONGITUDE.ToString())),
                    UTILITY.radius
                    );

                if (bookingsList != null)
                    return Ok(bookingsList);
                else
                    return Ok(new List<Booking>());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /* only for driver */
        
        [HttpPost]
        [Route("cancel")]        
        public IHttpActionResult CancelBookingByDriver(BookingCancelDTO bookingCancelDTO)
        {
            try
            {
                var result = new BookingBO().BookingCancelledByDriver(
                    HeaderValueByKey("AUTH_TOKEN"),
                    bookingCancelDTO.driverID, 
                    bookingCancelDTO.vehicleNo,
                    bookingCancelDTO.bookingNo,
                    bookingCancelDTO.cancelRemarks,
                    bookingCancelDTO.istripstarted);

                PushNotification(new BookingBO().GetCustomerDeviceIDByBookingNo(bookingCancelDTO.bookingNo), 
                    bookingCancelDTO.bookingNo, 
                    UTILITY.NotifyCancelledByDriver);

                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        
        [HttpPost]
        [Route("pickupreachdatetime")]
        public IHttpActionResult SavePickupReachDateTime(PickupReachDateTimeDTO obj)
        {
            try
            {
                var result = new BookingBO().SavePickupReachDateTime(obj.bookingNo, obj.PickupReachDateTime);
                if(result)
                    PushNotification(new BookingBO().GetCustomerDeviceIDByBookingNo(obj.bookingNo), obj.bookingNo, UTILITY.NotifyPickUpReachDateTime);
                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("destinationreachdatetime")]
        public IHttpActionResult SaveDestinationReachDateTime(DestinationReachDateTimeDTO obj)
        {
            try
            {
                var result = new BookingBO().SaveDestinationReachDateTime(obj.bookingNo, obj.DestinationReachDateTime);
                if (result)
                        PushNotification(new BookingBO().GetCustomerDeviceIDByBookingNo(obj.bookingNo), obj.bookingNo, UTILITY.NotifyDestinationReachDateTime);
                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("drivergeoposition/{driverID}")]
        public IHttpActionResult GetDriverGeoPosition(string driverID)
        {
            try
            {
                var driverActivity = new DriverActivityBO().GetDriverActivityByDriverID(new DriverActivity { DriverID = driverID });

                return Ok(new {
                    CurrentLat = driverActivity.CurrentLat,
                    CurrentLong = driverActivity.CurrentLong
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("tripestimate")]
        public IHttpActionResult GetTripEstimate(TripEstimateDTO tripEstimate)
        {
            var obj = GetTravelTimeBetweenTwoLocations(
                tripEstimate.frmLat.ToString() + "," + tripEstimate.frmLog.ToString(),
                tripEstimate.toLat.ToString() + "," + tripEstimate.toLog.ToString());

            return Ok(obj);
        }

       
    }
}
