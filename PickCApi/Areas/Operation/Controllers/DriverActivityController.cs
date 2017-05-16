using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

using Operation.Contract;
using Operation.BusinessFactory;

using Master.Contract;
using Master.BusinessFactory;

using PickCApi.Areas.Operation.DTO;
using PickCApi.Core;
using RestSharp;

namespace PickCApi.Areas.Operation.Controllers
{
    [RoutePrefix("api/operation/driveractivity")]
    public class DriverActivityController : ApiBase
    {
        [HttpGet]
        [Route("list")]
        [ApiAuthFilter]
        public IHttpActionResult DriverActivities()
        {
            try
            {
                var activities = new DriverActivityBO().GetList();
                if (activities != null)
                    return Ok(activities);
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
        [ApiAuthFilter]
        public IHttpActionResult SaveDriverActivity(DriverActivity driverActivity)
        {
            try
            {
                var result = new DriverActivityBO().SaveDriverActivity(driverActivity);
                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("login")]        
        public IHttpActionResult DriverLoginIn(DriverLoginDTO driverLoginDTO)
        {
            try
            {
                var token = new DriverActivityBO().DriverLogIn(driverLoginDTO.driverID, driverLoginDTO.password, driverLoginDTO.latitude, driverLoginDTO.longitude);
                if (!string.IsNullOrWhiteSpace(token))
                    return Ok(new {
                        token = token
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
        [Route("logout")]
        [ApiAuthFilter]
        public IHttpActionResult DriverLogOut()
        {
            try
            {
                var driverActivity = new DriverActivity {
                    DriverID = HeaderValueByKey("DRIVERID"),
                    TokenNo = HeaderValueByKey("AUTH_TOKEN"),
                    Latitude = Convert.ToDecimal(HeaderValueByKey("LATITUDE")),
                    Longitude = Convert.ToDecimal(HeaderValueByKey("LONGITUDE")),
                    IsLogIn = false,
                    IsOnDuty = false
                };

                var result = new DriverActivityBO().DriverActivityUpdate(driverActivity);

                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("dutystatus/{status}/{isintrip}/{tripID}")]
        [ApiAuthFilter]
        public IHttpActionResult UpdateDriverDutyStatus(bool status, bool isintrip, string tripID)
        {
            try
            {
                var driverActivity = new DriverActivity
                {
                    DriverID = HeaderValueByKey("DRIVERID"),
                    TokenNo = HeaderValueByKey("AUTH_TOKEN"),
                    Latitude = Convert.ToDecimal(HeaderValueByKey("LATITUDE")),
                    Longitude = Convert.ToDecimal(HeaderValueByKey("LONGITUDE")),
                    IsLogIn = true,
                    IsOnDuty = status
                };

                var driverActivityObj = new DriverActivity();
                if (isintrip)
                {
                    driverActivityObj = new DriverActivityBO().GetDriverActivity(new DriverActivity
                    {
                        TokenNo = HeaderValueByKey("AUTH_TOKEN"),
                        DriverID = HeaderValueByKey("DRIVERID")
                    });

                    var frmLatLong = driverActivityObj.CurrentLat.ToString() + "," + driverActivityObj.CurrentLong.ToString();
                    var toLatLong = driverActivity.Latitude + "," + driverActivity.Longitude;
                    var distance = GetTravelTimeBetweenTwoLocations(frmLatLong, toLatLong).distance;

                    new TripBO().TripUpdateTravelledDistance(tripID, distance);
                    
                }
                var result = new DriverActivityBO().DriverActivityUpdate(driverActivity);                

                return Ok(result ? UTILITY.SUCCESSMSG : UTILITY.FAILEDMSG);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /* only for user */
        [HttpPost]
        [Route("user")]
        [ApiAuthFilter]
        public IHttpActionResult GetTrucksInRange(TrucksInRangeDTO trucksInRangeDTO)
        {
            try
            {
                var trucks = new BookingBO().GetTrucksInRange(
                    HeaderValueByKey("MOBILENO"), 
                    trucksInRangeDTO.latitude, 
                    trucksInRangeDTO.longitude, 
                    UTILITY.radius, trucksInRangeDTO.vehicleGroup, trucksInRangeDTO.vehicleType);
                if (trucks != null)
                    return Ok(trucks);
                else
                    return Ok(new List<NearTrucksInRange>());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /* only for user */

        [HttpGet]
        [Route("{BookingNo}/{vehicleNo}")]
        [ApiAuthFilter]
        public IHttpActionResult ConfirmBooking(string BookingNo, string vehicleNo)
        {
            try
            {
                var bookingObj = new BookingBO().GetBooking(new Booking { BookingNo = BookingNo });
                if (!bookingObj.IsCancel)
                {
                    var result = new BookingBO().BookingConfirmByDriver(HeaderValueByKey("DRIVERID"), HeaderValueByKey("AUTH_TOKEN"), vehicleNo, BookingNo);
                    if (result)
                    {
                        PushNotification(new BookingBO().GetCustomerDeviceIDByBookingNo(BookingNo), BookingNo, UTILITY.NotifySuccess);

                    var booking = new BookingBO().GetBooking(new Booking
                    {
                        BookingNo = BookingNo
                    });
                    var driverList = new BookingBO().GetNearTrucksDeviceID(booking.BookingNo,
                        UTILITY.radius,
                        booking.VehicleType,
                        booking.VehicleGroup,
                        booking.Latitude,
                        booking.Longitude);                   

                    if (driverList.Count > 0)
                    {
                        var driverItem = driverList.Where(x => x.VehicleNo == vehicleNo).FirstOrDefault();
                        if (driverItem != null)
                            driverList.Remove(driverItem);

                        PushNotification(driverList.Select(x => x.DeviceID).ToList<string>(),
                            booking.BookingNo, UTILITY.NotifyBookingAcceptedByOtherDriver);
                    }
                }

                    return Ok(new
                    {
                        status = result
                    });
                }
                else
                {
                    var driver = new DriverBO().GetDriver(new Driver { DriverID = HeaderValueByKey("DRIVERID") });
                    PushNotification(driver.DeviceID,
                                BookingNo, UTILITY.NotifyBookingCancelledByUser);

                    return Ok(UTILITY.NotifyBookingCancelledByUser);
                }
            }
            catch (Exception ex)
            {
                if(ex.Message == "Booking is Already Confirmed by Other Driver!")
                {
                    var bookingInfo = new BookingBO().GetBooking(new Booking { BookingNo = BookingNo });
                    if (bookingInfo.DriverID == HeaderValueByKey("DRIVERID"))
                        return Ok("Booking is Already Confirmed by you..!");
                    else
                        return Ok("Booking is Already Confirmed by Other Driver..!");
                }
                else
                {
                    return InternalServerError(ex);
                }
            }
        }
    }    
}
