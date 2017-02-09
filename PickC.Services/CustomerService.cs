using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;

using Master.Contract;
using PickC.Services.DTO;


namespace PickC.Services
{
    public class CustomerService : Service
    {
        public CustomerService(string token, string mobileNo): base(token, mobileNo)
        {

        }

        public CustomerService(): base("","")
        {

        }
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

        public async Task<LoginDTO> LoginAsync(Customer customer)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "master/customer/login";
            request.AddJsonBody(customer);
            try
            {
                return ServiceResponse<LoginDTO>(
                    await client.ExecuteTaskAsync<LoginDTO>(request));
            }
            catch(Exception ex)
            {
                return new LoginDTO {
                    token = ex.Message
                };
            }
            
        }

        /* while calling this function session is not yet set */
        public async Task<Customer> GetCustomerInfoAsync(string token, string mobile)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.GET;

            request.AddHeader("AUTH_TOKEN", token);
            request.AddHeader("MOBILENO", mobile);

            request.Resource = "master/customer/{mobile}";
            request.AddParameter("mobile", mobile, ParameterType.UrlSegment);

            return ServiceResponse<Customer>(
                await client.ExecuteTaskAsync<Customer>(request));

        }

        public async Task<List<CustomerDTO>> GetCustomerListAsync()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "master/customer/list";

            return ServiceResponse<List<CustomerDTO>>(
                await client.ExecuteTaskAsync<List<CustomerDTO>>(request));
        }

        public async Task<string> UpdateCustomerAsync(Customer customer)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "master/customer/{mobile}";
            request.AddParameter("mobile", customer.MobileNo, ParameterType.UrlSegment);
            request.AddJsonBody(customer);

            return ServiceResponse(
                await client.ExecuteTaskAsync(request));
        }

        public async Task<string> LogoutAsync()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "master/customer/logout";

            return ServiceResponse(
                await client.ExecuteTaskAsync(request));
        }
    }
}
