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
    [RoutePrefix("api/master/ADtruck")]
    [OperatorAPIAuthFilter]
    public class ADtruckList : ApiBase
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult TruckList()
        {
            try
            {
                var truckList = new TruckBO().GetList();

                if (truckList != null)
                    return Ok(truckList);
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