using Operation.BusinessFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PickCApi.Areas.Operation.Controllers
{
    [RoutePrefix("api/opearation/payment")]
    public class PaymentController : ApiBase
    {
        [HttpPost]
        [Route("summary/{driverID}")]
        public IHttpActionResult GetDriverSummary(string driverID) {
            try
            {
                var result = new SummaryBO().GetSummary(driverID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("payments/{driverID}")]
        public IHttpActionResult GetDriverPayments(string driverID) {
            try
            {
                var result = new SummaryBO().GetPayments(driverID);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
