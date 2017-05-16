using Operation.BusinessFactory;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        [Route("getRSAKey")]
        public IHttpActionResult getRSAKey(RSAObject obj)
        {
            /*
            string vParams = "";
            foreach (string key in Request.Params.AllKeys)
            {
                vParams += key + "=" + Request[key] + "&";
            }*/
           string vParams = "access_code=" + obj.access_code + "&" + "order_id" + obj.order_id;

            string queryUrl = "https://secure.ccavenue.com/transaction/getRSAKey";
            var encStr = postPaymentRequestToGateway(queryUrl, vParams);
            return Ok(encStr);
        }

        [HttpGet]
        [Route("ccavenue/cancel")]
        public IHttpActionResult ccavenueCancel()
        {
            return Ok();
        }

        [HttpGet]
        [Route("ccavenue/redirect")]
        public IHttpActionResult redirect()
        {
            return Ok();
        }

        private string postPaymentRequestToGateway(String queryUrl, String urlParam)
        {
            String message = "";
            try
            {
                StreamWriter myWriter = null;// it will open a http connection with provided url
                WebRequest objRequest = WebRequest.Create(queryUrl);//send data using objxmlhttp object
                objRequest.Method = "POST";
                //objRequest.ContentLength = TranRequest.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";//to set content type
                myWriter = new System.IO.StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(urlParam);//send data
                myWriter.Close();//closed the myWriter object

                // Getting Response
                System.Net.HttpWebResponse objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();//receive the responce from objxmlhttp object 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(objResponse.GetResponseStream()))
                {
                    message = sr.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                Console.Write("Exception occured while connection." + exception);
            }
            return message;
        }
    }

    public class RSAObject
    {
        public string access_code { get; set; }
        public string order_id { get; set; }
    }
}
