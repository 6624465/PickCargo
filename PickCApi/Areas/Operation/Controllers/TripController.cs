﻿using System;
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

namespace PickCApi.Areas.Operation.Controllers
{
    [RoutePrefix("api/operation/trip")]
    [ApiAuthFilter]
    public class TripController : ApiBase
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult TripList()
        {
            try
            {
                var tripList = new TripBO().GetList();
                if (tripList != null)
                    return Ok(tripList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("start")]
        public IHttpActionResult StartTrip(Trip trip)
        {
            try
            {
                var result = new TripBO().SaveTrip(trip);
                if (result)
                {
                    var customerObj = new CustomerBO().GetCustomer(new Customer { MobileNo = trip.CustomerMobile });
                    var driverActivity = new DriverActivity
                    {
                        DriverID = HeaderValueByKey("DRIVERID"),
                        TokenNo = HeaderValueByKey("AUTH_TOKEN"),
                        Latitude = Convert.ToDecimal(HeaderValueByKey("LATITUDE")),
                        Longitude = Convert.ToDecimal(HeaderValueByKey("LONGITUDE")),
                        IsLogIn = true,
                        IsOnDuty = true
                    };

                    new DriverActivityBO().DriverActivityUpdate(driverActivity);

                    PushNotification(customerObj.DeviceID, "", UTILITY.NotifyTripStart);
                    return Ok(new
                    {
                        tripID = trip.TripID,
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

        [HttpPost]
        [Route("end")]
        public IHttpActionResult EndTrip(TripEndDTO tripEndDTO)
        {
            try
            {
                var tripInfo = new TripBO().GetTrip(new Trip { TripID = tripEndDTO.TripID });
                string frmLatLong = tripInfo.Latitude + "," + tripInfo.Longitude.ToString();
                string toLatLong = tripEndDTO.TripEndLat + "," + tripEndDTO.TripEndLong.ToString();
                decimal distance = GetTravelTimeBetweenTwoLocations(frmLatLong, toLatLong).distance;
                tripEndDTO.Token = HeaderValueByKey("AUTH_TOKEN");
                tripEndDTO.DriverID = HeaderValueByKey("DRIVERID");
                var result = new TripBO().EndTrip(tripEndDTO,distance);
                if (result)
                {
                     tripInfo = new TripBO().GetTrip(new Trip { TripID = tripEndDTO.TripID });                    
                    var customerObj = new CustomerBO().GetCustomer(new Customer { MobileNo = tripInfo.CustomerMobile });
                    PushNotification(customerObj.DeviceID, "", UTILITY.NotifyTripEnd);
                    return Ok(new
                    {
                        tripID = tripEndDTO.TripID,
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
        [Route("{tripId}")]
        public IHttpActionResult TripByTripID(string tripId)
        {
            try
            {
                var trip = new TripBO().GetTrip(new Trip { TripID = tripId });
                if (trip != null)
                    return Ok(trip);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{tripId}")]
        public IHttpActionResult DeleteTripByID(string tripId)
        {
            try
            {
                var result = new TripBO().DeleteTrip(new Trip { TripID = tripId });
                if (result)
                    return Ok(UTILITY.DELETEMSG);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("customer/isintrip")]
        public IHttpActionResult IsCustomerInTrip()
        {
            try
            {
                var trip = new TripBO().CustomerCurrentTrip(HeaderValueByKey("MOBILENO"));
                return Ok(new {
                    isintrip = trip != null ? true : false,
                    bookingno = (trip != null ? trip.BookingNo : "")
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("driver/isintrip")]
        public IHttpActionResult IsDriverInTrip()
        {
            try
            {
                try
                {
                    var trip = new TripBO().DriverCurrentTrip(HeaderValueByKey("DRIVERID"));
                    return Ok(new
                    {
                        isintrip = trip != null ? true : false,
                        tripid = (trip != null ? trip.TripID : ""),
                        bookingno = (trip != null ? trip.BookingNo : "")
                    });
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
