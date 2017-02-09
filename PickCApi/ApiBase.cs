using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PickCApi
{
    public class ApiBase : ApiController
    {
        public string HeaderValueByKey(string key)
        {
            IEnumerable<string> headerValues;
            var headerVal = string.Empty;
            if (Request.Headers.TryGetValues(key, out headerValues))
            {
                headerVal = headerValues.FirstOrDefault();
            }
            return headerVal;
        }

        public void PushNotification(string toDeviceId, string bookingNo, string message)
        {
            try
            {
                string applicationID = ConfigurationManager.AppSettings["appApplicationKey"];
                string senderId = ConfigurationManager.AppSettings["appSenderId"];
                
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = toDeviceId,                    
                    //notification = new
                    //{
                    //    body = message,
                    //    title = "Alert",
                    //    sound = "Enabled"
                    //},
                    data = new {
                        bookingNo = bookingNo,
                        body = message
                    }
                };

                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public void PushNotification(List<string> receipents, string bookingNo, string message)
        {
            try
            {
                string applicationID = ConfigurationManager.AppSettings["appApplicationKey"];
                string senderId = ConfigurationManager.AppSettings["appSenderId"];                
                
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {                    
                    registration_ids = receipents,
                    //notification = new
                    //{
                    //    body = message,
                    //    title = "Alert",
                    //    sound = "Enabled"
                    //},
                    data = new
                    {
                        bookingNo = bookingNo,
                        body = message
                    }
                };

                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        public string Nokeylist = "0123456789";
        public string GenerateOTP()
        {
            var password = "";
            Random r = new Random();
            int keyLength = Nokeylist.Length;
            for (var i = 0; i < 4; i++)
            {
                password += Nokeylist[r.Next(0, keyLength)];
            }
            return password;
        }

        public bool SendOTP(string To)
        {
           return new smsGenerator().ConfigSms(To,string.Format(UTILITY.SmsOTP, GenerateOTP()));
        }
        public bool SendOTP1(string To)
        {
            return new smsGenerator().ConfigSms(To, UTILITY.SmsConfirmTrip);
        }
        public bool SendOTP2(string To)
        {
            return new smsGenerator().ConfigSms(To, string.Format(UTILITY.SmsConfirmBooking, "BK160800001"));
        }

        public decimal GetTravelTimeBetweenTwoLocations(string frmLatLong, string toLatLong)
        {
            string API_KEY = ConfigurationManager.AppSettings["googleAPIKEY"];
            string API_URL = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" 
                + frmLatLong + "&destinations=" + toLatLong + "&key=" + API_KEY;

            var response = GoogleWebApi(API_URL);

            return 0.00M;
        }

        public decimal GoogleWebApi(string Url)
        {
            WebRequest request = WebRequest.Create(Url);
            using (WebResponse response = request.GetResponse())
            {
                decimal distance = 0.00M;
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    var obj = JsonConvert.DeserializeObject<GoogleApiResponse>(sr.ReadToEnd());
                    if (obj.rows.Count() > 0)
                    {
                        if(obj.rows[0].elements.Count > 0)
                        {
                            if(obj.rows[0].elements[0].distance != null)
                            {
                                distance = (obj.rows[0].elements[0].distance.value / 1000);
                            }
                        }
                    }
                }
                return distance;
            }
        }
    }

    public class GoogleApiResponse
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }

        public List<Rows> rows { get; set; }

        public string status { get; set; }
    }  
    
    public class Rows
    {
        public List<Element> elements { get; set; }
    }  

    public class Element
    {
        public KeyValue distance { get; set; }

        public KeyValue duration { get; set; }

        public string status { get; set; }
    }

    public class KeyValue
    {
        public string text { get; set; }

        public int value { get; set; }
    }    
}
