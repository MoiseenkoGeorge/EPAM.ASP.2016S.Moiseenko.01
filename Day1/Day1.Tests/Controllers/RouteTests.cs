using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;
using Day1.Controllers;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Day1.Tests.Controllers
{
    public static class Helper
    {
        public static HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(
                Moq.It.IsAny<string>())).Returns<string>(s => s);

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }
        public static bool TestIncomingRouteResult(RouteData routeResult,string controller, string action, object propertySet = null)
        {

            Func<object, object, bool> valCompare = (v1, v2) => StringComparer.InvariantCultureIgnoreCase
                .Compare(v1, v2) == 0;

            var result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet == null) return result;
            PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
            if (propInfo.Any(pi => !(routeResult.Values.ContainsKey(pi.Name)
                                     && valCompare(routeResult.Values[pi.Name],
                                         pi.GetValue(propertySet, null)))))
            {
                result = false;
            }
            return result;
        }
    }

    [Subject("rout is available")]
    public class TestRouteMatch
    {
        private static RouteData result;
        private static RouteCollection routes;
        private static string controller = "Home";
        private static string action = "Index";

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        };

        Because of = () =>
            result = routes.GetRouteData(Helper.CreateHttpContext("~/Home/Index/aabbbb"));

        It rout_should_be_available = () => 
            Helper.TestIncomingRouteResult(result, controller, action).ShouldBeTrue();
    }

    public class TestRouteFail
    {
        private static RouteData result;
        private static RouteCollection routes;

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        };

        Because of = () =>
            result = routes.GetRouteData(Helper.CreateHttpContext("~/Home/Index/123"));

        It rout_should_be_failed = () =>
            (result?.Route == null).ShouldBeTrue();
    }

}
