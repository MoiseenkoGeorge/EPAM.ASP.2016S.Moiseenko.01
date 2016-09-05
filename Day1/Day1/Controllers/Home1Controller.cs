using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1.AdditionalControllers
{
    public class HomeController : Controller
    {
        // Post: Home
        public JsonResult Index()
        {
            return new JsonResult();
        }
    }
}