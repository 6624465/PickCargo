using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using Master.Contract;

using PickC.Services;
using PickC.Services.DTO;

namespace PickC.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Customer());
        }

        [HttpPost]
        public async Task<ActionResult> Login(Customer customer)
        {
            try
            {
                var loginDTO = await new CustomerService().LoginAsync(customer);
                if (loginDTO != null && !string.IsNullOrWhiteSpace(loginDTO.token))
                {
                    HttpContext.Session["SSN_TOKEN"] = loginDTO.token;
                    var customerObj = await new CustomerService().GetCustomerInfoAsync(loginDTO.token, customer.MobileNo);
                    HttpContext.Session["SSN_CUSTOMER"] = customerObj;

                    return RedirectToAction("Index", "Home");
                }
                else
                    return View("Login");
            }
            catch (Exception ex)
            {
                ViewBag.ErrMsg = ex.Message;
                return Content(ex.Message);
            }

        }

        [HttpGet]
        [WebAuthFilter]
        public async Task<ActionResult> Logoff()
        {
            var result = await new CustomerService(AUTHTOKEN, p_mobileNo).LogoutAsync();
            if (result == "USER LOGGEDOUT SUCCESSFULLY")
            {
                Session.Abandon();
                Session.Clear();
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [WebAuthFilter]
        public ActionResult CustomerProfile()
        {
            var customerObj = (Customer)HttpContext.Session["SSN_CUSTOMER"];
            return View(customerObj);
        }

        [HttpPost]
        [WebAuthFilter]
        public async Task<ActionResult> CustomerProfile(Customer customer)
        {
            var result = await new CustomerService().UpdateCustomerAsync(customer);
            if (result == "SAVED SUCSSFULLY")
                HttpContext.Session["SSN_CUSTOMER"] = customer;
            return RedirectToAction("Index", "Home");
        }


    }
}