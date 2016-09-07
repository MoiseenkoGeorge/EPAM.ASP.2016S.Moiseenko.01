using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Day2.Controllers;

namespace Day2.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if(!requestContext.HttpContext.Request.IsLocal)
                throw new AccessViolationException();
            Type targetType = null;
            controllerName = controllerName.ToLower();
            switch (controllerName)
            {
                case "base":
                    targetType = typeof(BaseController);
                    break;
                case "user":
                case "customer":
                    targetType = typeof(CustomerController);
                    break;
                case "admin":
                    targetType = typeof (AdminController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Home";
                    targetType = typeof(HomeController);
                    break;
            }
            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return controllerName == "Home" ? SessionStateBehavior.Disabled : SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}