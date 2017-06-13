using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickC.Web.Controllers
{
    public class HelpController : BaseController
    {
        public ActionResult menu(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return View("menu", "_Layout");
            else
                return View(name, "_Layout");
        }

        public ActionResult Services()
        {
            return View();
        }
        public ActionResult mobilehelp()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult FeedBack()
        {
            return View();
        }

        public ActionResult FAQS()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        public ActionResult Careers()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Support() {
            return View();
        }
    }
}