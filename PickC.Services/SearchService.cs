using Operation.Contract;
using PickC.Services.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickC.Services
{
    public class SearchService:Service
    {
        public SearchService(string token, string mobileNo): base(token, mobileNo)
        {

        }
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public async Task<List<Booking>> SearchCurrentBookingAsync(BookingDTO bookingDTO)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "operation/search/currentbooking";
            request.AddJsonBody(bookingDTO);

            return ServiceResponse(
                await client.ExecuteTaskAsync<List<Booking>>(request));
        }

        public async Task<List<Booking>> SearchBookingByDateAsync(BookingSearchDTO booking) {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "operation/search/bookingbydate";
            request.AddJsonBody(booking);

            //request.AddParameter("fromDate", fromDate, ParameterType.UrlSegment);
            //request.AddParameter("toDate", toDate, ParameterType.UrlSegment);

            return ServiceResponse(await client.ExecuteTaskAsync<List<Booking>>(request));
        }
    }
}
