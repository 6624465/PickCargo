using System.Net;
using System.Net.Http;
using System.Web.Http;

using Master.Contract;
using Master.BusinessFactory;
using PickCApi.Core;
using PickCApi.Areas.Master.DTO;
using PickC.Services.DTO;
using System.Linq;
using System;
using System.Web;
namespace PickCApi.Areas.Master.Controllers
{
    [RoutePrefix("api/master/ADdriver")]
    //[ApiAuthFilter]
    public class ADdriverController : ApiBase
    { 
        [HttpPost]
        //[Route("changepassword/{driverID}")]
        [Route("changepassword")]
        [ApiAuthFilter]
        public IHttpActionResult ChangePassword(DriverPassword driverPassword)
        {
            try
            {
                var result = new DriverBO().UpdateDriverPassword(driverPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
        [HttpPost]
        [Route("updateDriver")]
        [ApiAuthFilter]
        public IHttpActionResult UpdateDriver(Driver driver)
        {
            try
            {
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                var driverBO = new DriverBO();
                var driverObj = driverBO.GetDriver(new Driver {DriverID= DRIVERID });
                if (driverObj != null)
                {
                    driverObj.DriverName = driver.DriverName;
                    driverObj.Password = driver.Password;
                    driverObj.ModifiedBy = "ADMIN";

                    var result = driverBO.SaveDriver(driverObj);
                    if (result)
                        return Ok(UTILITY.SUCCESSMSG);
                    else
                        return BadRequest();
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("getDriver")]
        [ApiAuthFilter]
        public IHttpActionResult GetDriver()
        {
            try
            {
                var driverBO = new DriverBO();
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                var driverObj = driverBO.GetDriver(new Driver { DriverID = DRIVERID });
                if (driverObj != null)
                {
                    return Ok(driverObj);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("DriverListOfTrips")]
        [ApiAuthFilter]
        public IHttpActionResult DriverTodayListOfTrips()
        {
            try
            {
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                var TodayListOfTrips = new DriverBO().GetTodayListOfTrips(DRIVERID);
                return Ok(TodayListOfTrips);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("DriverTripCount")]
        [ApiAuthFilter]
        public IHttpActionResult TodayTripCount()
        {
            try
            {
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                int tripCount = new DriverBO().GetTripCountbyDriverID(DRIVERID);
                return Ok(new { tripCount });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("DriverTripAmount")]
        [ApiAuthFilter]
        public IHttpActionResult TodayTripAmount()
        {
            try
            {
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                decimal tripAmount = new DriverBO().GetTripAmountbyDriverID(DRIVERID);
                return Ok(new { tripAmount });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("GetDriverTripAmountbyPaymentType")]
        [ApiAuthFilter]
        public IHttpActionResult GetDriverTripAmountbyPaymentType()
        {
            try
            {
                var driverBO = new DriverBO();
                var DRIVERID = HttpContext.Current.Request.Headers["DRIVERID"];
                var driverObj = driverBO.GetDriverTripAmountbyPaymentType(DRIVERID);
                if (driverObj != null)
                {
                    return Ok(driverObj );
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("DriverReferral")]
        [ApiAuthFilter]
        public IHttpActionResult DriverReferral(DriverReferral driverReferral)
        {
            try
            {
                var result = new DriverBO().SaveDriverReferral(driverReferral);
                if (result)
                {
                    SendOTP(driverReferral.Mobile,"You have been Referred for PickC Services!");
                    return Ok(UTILITY.SUCCESSMSG);
                }
                else
                    return BadRequest();
                //return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}
