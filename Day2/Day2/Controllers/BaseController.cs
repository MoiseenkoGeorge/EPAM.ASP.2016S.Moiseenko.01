using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2.Controllers
{
    public class BaseController : Controller
    {
       protected override void HandleUnknownAction(string actionName)
        {
            ViewData["actionName"] = actionName;
            View("Custom404").ExecuteResult(this.ControllerContext);
        }
    }
}