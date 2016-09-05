//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Day2.Infrastructure
//{
//    public class CustomActionInvoker : IActionInvoker
//    {
//        public bool InvokeAction(ControllerContext controllerContext, string actionName)
//        {
//            if (actionName != "Index") return false;

//            controllerContext.HttpContext.Response.Write("This is output from the IndexAction");

//            return true;
//        }
//    }
//}