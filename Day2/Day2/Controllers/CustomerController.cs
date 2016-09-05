using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Day2.Infrastructure;
using Day2.Models;

//using Day2.Models;

namespace Day2.Controllers
{
    public class CustomerController : Controller
    {
        [ActionName("Add-User")]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [ActionName("Add-User")]
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            var data = await StaticUserRepository.Add(user);
            UsersViewModel users = new UsersViewModel {Users = data};
            return View("ViewUsers",users);
        }

        [ActionName("User-List")]
        [HttpGet]
        public ActionResult UserList()
        {
            return View("ViewUsers", new UsersViewModel() {Users = StaticUserRepository.GetAll()});
        }

        [ActionName("User-List")]
        [HttpPost]
        public JsonResult UserListpost()
        {
            return new JsonResult();
        }
    }
}