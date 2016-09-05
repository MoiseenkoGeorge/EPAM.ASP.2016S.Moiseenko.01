using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.Infrastructure;

namespace Day2.Controllers
{

    public class AdminController : Controller
    {
        [Local]
        [HttpGet]
        public ActionResult Edit()
        {
            return View("");
        }
    }
}