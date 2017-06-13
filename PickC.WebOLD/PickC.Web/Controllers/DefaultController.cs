using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickC.Web.Controllers
{
    public class DefaultController : BaseController
    {

        public ActionResult menu(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return View("menu");
            else
                return View(name);
        }
    }
}