using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Master.Contract;
using Master.BusinessFactory;
using Operation.BusinessFactory;
using Operation.Contract;
using PickCApi.Core;

using PickCApi.Areas.Master.DTO;

namespace PickCApi.Areas.Master.Controllers
{
    [RoutePrefix("api/master/customer")]
    public class RegisterController : ApiController
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            try
            {
                var result = new CustomerBO().SaveCustomer(customer);
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

        [HttpPost]
        [Route("{mobile}")]
        [ApiAuthFilter]
        public IHttpActionResult UpdateCustomer(string mobile, Customer customer)
        {
            try
            {
                var customerBO = new CustomerBO();
                var customerObj = customerBO.GetCustomer(new Customer { MobileNo =  mobile });
                if (customerObj != null)
                {
                    customerObj.Name = customer.Name;
                    customerObj.EmailID = customer.EmailID;
                    customerObj.Password = customer.Password;

                    var result = customerBO.SaveCustomer(customerObj);
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
        [Route("{mobile}")]
        [ApiAuthFilter]
        public IHttpActionResult GetCustomer(string mobile)
        {
            try
            {
                var customer = new CustomerBO()
                                    .GetCustomer(new Customer
                                    {
                                        MobileNo = mobile
                                    });
                if (customer != null)
                    return Ok(new {
                        MobileNo = customer.MobileNo,
                        Name = customer.Name,
                        EmailID = customer.EmailID
                    });
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("deviceid")]
        [ApiAuthFilter]
        public IHttpActionResult UpdateDeviceId(CustomerDeviceDTO customerDeviceDTO)
        {
            try
            {
                var result = new CustomerBO().UpdateCustomerDevice(customerDeviceDTO.mobileNo, customerDeviceDTO.deviceId);
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
        [Route("{mobile}")]
        [ApiAuthFilter]
        public IHttpActionResult DeleteCustomer(string mobile)
        {
            try
            {
                var result = new CustomerBO()
                                    .DeleteCustomer(new Customer
                                    {
                                        MobileNo = mobile
                                    });
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
        [Route("list")]
        [ApiAuthFilter]
        public IHttpActionResult GetCustomerList()
        {
            try
            {
                var customerList = new CustomerBO().GetList().Select(x => new {
                    MobileNo = x.MobileNo,
                    Name = x.Name,
                    EmailID = x.EmailID
                }).ToList();
                if (customerList != null)
                    return Ok(customerList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(Customer customer)
        {
            try
            {
                var token = new CustomerLogInBO().CustomerLogIn(customer.MobileNo, customer.Password);

                if (!string.IsNullOrWhiteSpace(token))
                    return Ok(new {
                        token= token
                    });
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("changepassword/{mobile}")]
        [ApiAuthFilter]
        public IHttpActionResult ChangePassword(CustomerPassword customerPassword)
        {
            try
            {
                var result = new CustomerBO().UpdateCustomerPassword(customerPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("logout")]
        [ApiAuthFilter]
        public IHttpActionResult Logout()
        {
            try
            {
                IEnumerable<string> headerValues;
                var token = string.Empty;
                if (Request.Headers.TryGetValues("AUTH_TOKEN", out headerValues))
                {
                    token = headerValues.FirstOrDefault();
                }
                var result = new CustomerLogInBO()
                    .DeleteCustomerLogIn(new CustomerLogin { TokenNo = token });

                if (result)
                    return Ok(UTILITY.LOGOUT);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("check/{mobile}")]
        public IHttpActionResult CheckMobile(string mobile)
        {
            try
            {
                bool result = false;
                var customerList = new CustomerBO().GetList();

                if(customerList != null)
                {
                    result = customerList.Where(x => x.MobileNo == mobile).ToList().Count() > 0;
                    return Ok(result);
                }
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
