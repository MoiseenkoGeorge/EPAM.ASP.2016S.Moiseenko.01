using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using Day4.Models;

namespace Day4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formData)
        {
            Person person = new Person();
            UpdateModel(person,formData);
            return View(person);
        }
    }
}