using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day2.Infrastructure;
using Day2.Models;

namespace Day2.Controllers
{

    public class AdminController : Controller
    {
        //[Local]
        [HttpGet]
        public ActionResult Edit()
        {
            return View(new UsersViewModel() { Users = StaticUserRepository.GetAll() });
        }

        //[Local]
        [HttpPost]
        public ActionResult Edit(UsersViewModel users)
        {
            StaticUserRepository.DeleteAll();
            return View(new UsersViewModel() { Users = StaticUserRepository.GetAll() });
        }
    }
}