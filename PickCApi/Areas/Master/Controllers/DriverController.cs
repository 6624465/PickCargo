﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Master.Contract;
using Master.BusinessFactory;
using PickCApi.Core;
using PickCApi.Areas.Master.DTO;

namespace PickCApi.Areas.Master.Controllers
{
    [RoutePrefix("api/master/driver")]
    [ApiAuthFilter]
    public class DriverController : ApiController
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult DriverList()
        {
            try
            {
                var driverList = new DriverBO().GetList();

                if (driverList != null)
                    return Ok(driverList);
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
        public IHttpActionResult SaveDriver(Driver driver)
        {
            try
            {
                driver.CreatedBy = UTILITY.DEFAULTUSER;
                driver.ModifiedBy = UTILITY.DEFAULTUSER;
                driver.CreatedOn = DateTime.Now;
                driver.ModifiedOn = DateTime.Now;

                driver.AddressList.ForEach(x => {
                    x.AddressLinkID = driver.DriverID;
                    x.AddressType = "DRIVER";
                    x.CreatedBy = UTILITY.DEFAULTUSER;
                    x.CreatedOn = DateTime.Now;
                    x.ModifiedBy = UTILITY.DEFAULTUSER;
                    x.ModifiedOn = DateTime.Now;
                    x.IsActive = true;
                });

                var result = new DriverBO().SaveDriver(driver);
                if (result)
                    return Ok(UTILITY.SUCCESSMSG);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{driverID}")]
        public IHttpActionResult DeleteDriver(string driverID)
        {
            try
            {
                var result = new DriverBO().DeleteDriver(new Driver { DriverID = driverID });
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
        [Route("{driverID}")]
        public IHttpActionResult DriverInfo(string driverID)
        {
            try
            {
                var driver = new DriverBO().GetDriver(new Driver { DriverID = driverID });
                if (driver != null)
                    return Ok(driver);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("lookupdata")]
        public IHttpActionResult LookUpData()
        {
            try
            {
                var lookupList = new LookUpBO().GetList();

                var genderOptions = lookupList.Where(x => x.LookupCategory == "Gender").ToList();
                var maritalOptions = lookupList.Where(x => x.LookupCategory == "MaritalStatus").ToList();

                return Ok(new {
                    genderOptions = genderOptions,
                    maritalOptions = maritalOptions
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }        

        [HttpPost]
        [Route("deviceid")]
        public IHttpActionResult UpdateDeviceId(DriverDeviceDTO driverDeviceDTO)
        {
            try
            {
                var result = new DriverBO().UpdateDriverDevice(driverDeviceDTO.driverId, driverDeviceDTO.deviceId);
                if (result)
                    return Ok(UTILITY.SUCCESSMSG);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
