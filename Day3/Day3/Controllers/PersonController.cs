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
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            return View("Person",StaticUserRepository.Users[id]);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            user.Side = Side.Dark;
            StaticUserRepository.Users.Single(u => u.Name == user.Name).Side = Side.Dark;
            return View("Person", user);
        }
        [ChildActionOnly]
        public ActionResult Footer(User user)
        {
            return PartialView("Footer", user);
        }
    }
}