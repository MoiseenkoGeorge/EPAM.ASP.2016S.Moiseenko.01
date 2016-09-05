using System.Web;
using System.Web.Routing;

namespace Day1
{
    public class CustomRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return httpContext.Request.AppRelativeCurrentExecutionFilePath.Contains("aa");
        }
    }
}