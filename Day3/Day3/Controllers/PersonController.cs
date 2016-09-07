using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using Day3.Infrastructure;

namespace Day3.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(int id)
        {
            return View("Person",StaticUserRepository.Users[id]);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("Footer");
        }
    }
}