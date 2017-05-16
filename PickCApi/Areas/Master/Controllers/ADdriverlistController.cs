using System.Net;
using System.Net.Http;
using System.Web.Http;

using Master.Contract;
using Master.BusinessFactory;
using PickCApi.Core;
using PickCApi.Areas.Master.DTO;
using PickC.Services.DTO;
using System;

namespace PickCApi.Areas.Master.Controllers
{   
    [RoutePrefix("api/master/ADdriver")]
    [OperatorAPIAuthFilter]
    public class ADdriverlistController : ApiBase
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
    }
}
